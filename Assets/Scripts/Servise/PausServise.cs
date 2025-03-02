using System;
using Agava.WebUtility;
using System.Collections.Generic;
using UnityEngine;

public class PausServise : MonoBehaviour
{
    [SerializeField] private bool _isPaus;

    private readonly List<IPausableObject> _pausableObjects = new List<IPausableObject>();

    private bool _lastState;

    private void Awake()
    {
        WebApplication.InBackgroundChangeEvent += OnBackgroundChanged;
    }

    private void OnDestory()
    {
        WebApplication.InBackgroundChangeEvent -= OnBackgroundChanged;
    }

    private void Update()
    {
        if (_lastState != _isPaus)
        {
            _lastState = _isPaus;

            if (_isPaus)
                Paus();
            else
                UnPaus();
        }
    }

    public void Add(IPausableObject pausableObject)
    {
        if (pausableObject == null)
            throw new NullReferenceException();

        _pausableObjects.Add(pausableObject);
    }

    public void Remove(IPausableObject pausableObject)
    {
        if (pausableObject == null)
            throw new NullReferenceException();

        _pausableObjects.Remove(pausableObject);
    }

    public void Paus()
    {
        _pausableObjects.ForEach(pausableObject => pausableObject.Paus());
    }

    public void UnPaus()
    {
        _pausableObjects.ForEach(pausableObject => pausableObject.UnPaus());
    }

    private void OnBackgroundChanged(bool inBackground)
    {
        if (inBackground)
            Paus();
        else
            UnPaus();
    }
}
