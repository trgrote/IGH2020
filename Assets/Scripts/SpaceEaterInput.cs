using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpaceEaterMovement))]
public class SpaceEaterInput : MonoBehaviour
{
    Vector3 _direction = Vector3.zero;
    float _speed = 5f;

    // When there's an input event, that means the input value has changed.
    // Continious dispatch doesn't happen, so we need to store the input value as state
    public void Move(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();

        _direction.x = value.x;
        _direction.y = 0;
        _direction.z = value.y;
    }

    void FixedUpdate()
    {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(_direction * _speed, ForceMode.Force);
    }
}
