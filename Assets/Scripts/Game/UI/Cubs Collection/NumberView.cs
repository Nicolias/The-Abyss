using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberView : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _showTime;
    [SerializeField] private Vector3 _moveVector;

    private float _timeLeft;
    private GameObject _gameObject;
    private Transform _transform;

    public event Action<NumberView> Disabled;

    private void OnValidate()
    {
        gameObject.SetActive(true);
    }
    
    private void Awake()
    {
        _gameObject = gameObject;
        _transform = transform;
        _gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_timeLeft <= 0)
            Disable();
        
        if(_gameObject.activeInHierarchy == false)
            return;

        _transform.position += _moveVector * _speed * Time.deltaTime;
        _timeLeft -= Time.deltaTime;
    }

    public void Show(Vector3 startPosition)
    {
        _gameObject.SetActive(true);
        _transform.position = startPosition;
        _timeLeft = _showTime;
    }

    private void Disable()
    {
        _gameObject.SetActive(false);
        Disabled?.Invoke(this);
    }
}