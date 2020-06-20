using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateWorld : MonoBehaviour
{
    private Transform world;
    private CharacterController controller;
    private Vector3 velocity = Vector3.zero;
    private float speed = 3;
    // Start is called before the first frame update
    public void Start()
    {
        world = this.transform;
        controller = GetComponent<CharacterController>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        var newMovement = context.ReadValue<Vector2>();

        velocity.z = newMovement.x;
        world.Rotate(velocity);
    }

    // Update is called once per frame
    public void Update()
    {
    }
}
