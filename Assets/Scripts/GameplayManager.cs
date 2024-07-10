using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameplayManager : MonoBehaviour
{
    private bool _hasGameFinished;
    private float _score;
    private float _scoreSpeed;
    private int _currentLevel;

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private List<int> _levelSpeeds, _levelMaxValues;

    private void Awake()
    {
        GameManager.Instance.IsInitialized = true;
        _hasGameFinished = false;
        _score = 0;
        _currentLevel = 0;
        _scoreText.text = ((int)_score).ToString();

        _scoreSpeed = _levelSpeeds[_currentLevel];
    }
    private void Update()
    {
        if (_hasGameFinished)
        {
            return;
        }
        _score += _scoreSpeed * Time.deltaTime; 
        _scoreText.text = ((int)_score).ToString();

        if(_score > _levelMaxValues[Mathf.Clamp(_currentLevel, 0, _levelSpeeds.Count - 1)])
        {
            _currentLevel = Mathf.Clamp(_currentLevel + 1, 0 , _levelSpeeds.Count - 1);
            _scoreSpeed = _levelSpeeds[_currentLevel];
        }
    }

    public void GameEnded()
    {
        _hasGameFinished = true;
        GameManager.Instance.CurrentScore = (int)_score;
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.GoToMainMenu();
    }
}
