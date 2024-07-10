using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private const string _mainMenu = "MainMenu";
    private const string _gameplay = "Gameplay";
    private string _highScoreKey = "HighScore";

    public bool IsInitialized {  get; set; }
    public int CurrentScore { get; set; }



    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(_highScoreKey, 0);
        }
        set
        {
            PlayerPrefs.SetInt(_highScoreKey, value);
        }
    }

    private void Init()
    {
        CurrentScore = 0;
        IsInitialized = false;
    }

    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_mainMenu);
    }

    public void GoToGameplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_gameplay);
    }

}
