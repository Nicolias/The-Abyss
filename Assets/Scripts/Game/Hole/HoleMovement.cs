using System;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _speed;
    
    private void FixedUpdate()
    {
        Vector2 direction = Vector2.up * _joystick.Vertical + Vector2.right * _joystick.Horizontal;

        transform.position += new Vector3(direction.x, 0, direction.y) 
                             * _speed 
                             * Time.fixedDeltaTime;
    }

    public void AddSpeed(float speedFactor)
    {
        if (speedFactor < 0)
            throw new ArgumentOutOfRangeException();

        _speed *= speedFactor;
    }

    public void RemoveSpeed(float speedFactor)
    {
        if (speedFactor < 0)
            throw new ArgumentOutOfRangeException();

        _speed /= speedFactor;
    }
}
