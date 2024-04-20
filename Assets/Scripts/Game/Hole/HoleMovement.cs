using System.Collections;
using System.Collections.Generic;
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
}
