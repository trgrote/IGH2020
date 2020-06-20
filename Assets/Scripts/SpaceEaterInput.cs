using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpaceEaterMovement))]
[RequireComponent(typeof(Animator))]
public class SpaceEaterInput : MonoBehaviour
{
    Vector3 _direction = Vector3.zero;

    [SerializeField] float _speed = 5f;
    [SerializeField] float _rotationSpeed = 270f;   // degrees per second

    // When there's an input event, that means the input value has changed.
    // Continious dispatch doesn't happen, so we need to store the input value as state
    public void Move(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();

        _direction.x = value.x;
        _direction.y = 0;
        _direction.z = -value.y;
    }

    void FixedUpdate()
    {
        var rigidBody = GetComponent<Rigidbody>();
        var relativeDirection = Camera.main.worldToCameraMatrix * _direction;
        rigidBody.velocity = relativeDirection.normalized * _speed;

        // Only Modify Rotation is the direction isn't zero, because that means they just stopped input.
        // We don't want to snap back to looking down the Z axis
        if (_direction.sqrMagnitude > 0)
        {
            var targetRotation = Quaternion.LookRotation(rigidBody.velocity, Vector3.up);
            var step = _rotationSpeed * Time.fixedDeltaTime;
            rigidBody.MoveRotation(Quaternion.RotateTowards(rigidBody.rotation, targetRotation, step));
        }

        // Update Animation Parameters
        var animator = GetComponent<Animator>();
        var magnitude = rigidBody.velocity.magnitude;
        animator.SetFloat("Speed", rigidBody.velocity.magnitude);
        animator.SetBool("Walking", magnitude > 0);
    }
}
