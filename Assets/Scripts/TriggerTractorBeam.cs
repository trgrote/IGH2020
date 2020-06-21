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
    [SerializeField] private GameObject monsterObject;
    private ParticleSystem beam;
    private CapsuleCollider beamRange;
    private float movementDirection = 0;
    private int movementSpeed = 10;
    public bool isSucking = false;
    // Start is called before the first frame update
    void Start()
    {
        beam = monsterObject.GetComponentInChildren<ParticleSystem>();
        beam.Stop();
        beamRange = monsterObject.GetComponent<CapsuleCollider>();
        beamRange.enabled = false;
    }

    public void RotateWorld(InputAction.CallbackContext context)
    {
        var newMovement = context.ReadValue<Vector2>();
        movementDirection = newMovement.x;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        isSucking = context.ReadValue<float>() == 1;
        
        calmMusic.volume = isSucking ? 0 : 0.25f;
        intenseMusic.volume = isSucking ? 0.25f : 0;
        secondLight.intensity = isSucking ? 2 : 0.75f;
        if (isSucking) { beam.Play(); } else { beam.Stop(); }
        beamRange.enabled = isSucking;
    }

    // Update is called once per frame
    void Update()
    {
        worldObject.transform.Rotate(new Vector3(0,0, movementDirection * Time.deltaTime * movementSpeed));
    }
}
