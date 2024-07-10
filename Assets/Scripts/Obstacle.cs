using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool HasGameFinished;

    private float _currentRotateSpeed;
    private float _rotateTime;
    private float _currentRotateTime;
    [SerializeField] private float _minRotateSpeed, _maxRotateSpeed;
    [SerializeField] private float _minRotateTime, _maxRotateTime;

    private void Awake()
    {
        HasGameFinished = false;

        SetObstacleRotation();
    }

    private void Update()
    {
        _currentRotateTime += Time.deltaTime;

        if(_currentRotateTime > _rotateTime)
        {
            SetObstacleRotation();
        }
    }

    private void FixedUpdate()
    {
        if (HasGameFinished) return;
        transform.Rotate(0, 0, _currentRotateSpeed * Time.fixedDeltaTime);
    }

    private void SetObstacleRotation()
    {
        _currentRotateTime = 0f;
        _currentRotateSpeed = _minRotateSpeed + (_maxRotateSpeed - _minRotateSpeed) * Random.Range(0, 11) * 0.1f;
        _rotateTime = _minRotateTime + (_maxRotateTime - _minRotateTime) * Random.Range(0, 11) * 0.1f;
        _currentRotateSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;
    }
}
