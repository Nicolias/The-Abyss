using Reflex.Attributes;
using System;
using UnityEngine;

public class HoleMovement : MonoBehaviour, IPausableObject
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _speed;

    private float _currentSpeed;

    [Inject]
    public void Cunstruct(PausServise pausServise)
    {
        pausServise.Add(this);
    }

    private void Awake()
    {
        _currentSpeed = _speed;
    }

    private void FixedUpdate()
    {
        Vector2 direction = Vector2.up * _joystick.Vertical + Vector2.right * _joystick.Horizontal;

        transform.position += new Vector3(direction.x, 0, direction.y) 
                             * _currentSpeed 
                             * Time.fixedDeltaTime;
    }

    public void AddSpeed(float speedFactor)
    {
        if (speedFactor < 0)
            throw new ArgumentOutOfRangeException();

        _currentSpeed *= speedFactor;
    }

    public void RemoveSpeed(float speedFactor)
    {
        if (speedFactor < 0)
            throw new ArgumentOutOfRangeException();

        _currentSpeed /= speedFactor;
    }

    public void Stop()
    {
        _currentSpeed = 0;
    }

    public void Paus()
    {
        _currentSpeed = 0;
    }

    public void UnPaus()
    {
        _currentSpeed = _speed;
    }
}
