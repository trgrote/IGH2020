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

    // In the Update, we apply the direction to the movement continiously
    // The movement will be zero once input stops
    public void Update()
    {
        var controller = GetComponent<CharacterController>();
        controller.Move(_direction * Time.deltaTime * _speed);
    }
}
