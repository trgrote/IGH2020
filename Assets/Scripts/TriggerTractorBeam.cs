using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerTractorBeam : MonoBehaviour
{
    [SerializeField] private AudioSource calmMusic;
    [SerializeField] private AudioSource intenseMusic;
    [SerializeField] private Light secondLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("GOT SOMETHING: ");
        var newVal = context.ReadValue<float>();

        calmMusic.volume = newVal == 1 ? 0 : 1;
        intenseMusic.volume = newVal;
        secondLight.intensity = newVal == 1 ? 2 : 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
