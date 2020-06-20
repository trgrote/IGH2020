using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerTractorBeam : MonoBehaviour
{
    [SerializeField] private AudioSource calmMusic;
    [SerializeField] private AudioSource intenseMusic;
    [SerializeField] private Light secondLight;
    [SerializeField] private GameObject worldObject;
    private float movementDirection = 0;
    private int movementSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RotateWorld(InputAction.CallbackContext context)
    {
        var newMovement = context.ReadValue<Vector2>();
        movementDirection = newMovement.x;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        var newVal = context.ReadValue<float>();

        calmMusic.volume = newVal == 1 ? 0 : 1;
        intenseMusic.volume = newVal;
        secondLight.intensity = newVal == 1 ? 2 : 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        worldObject.transform.Rotate(new Vector3(0,0, movementDirection * Time.deltaTime * movementSpeed));
    }
}
