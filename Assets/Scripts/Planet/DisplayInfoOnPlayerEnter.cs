using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class DisplayInfoOnPlayerEnter : MonoBehaviour
{
    [SerializeField] TextMeshPro _text;
    [SerializeField] LookAtConstraint _lookAtConstraint;

    [SerializeField] rho.RuntimeGameObjectSet _players;

    [SerializeField] PlanetInfo _planetInfo;

    void Start()
    {
        _lookAtConstraint.enabled = false;
        _text.enabled = false;
    }

    void Update()
    {
        // Set Text based off population
        if (_planetInfo.CanEnter())
        {
            _text.text = $"Pop. {_planetInfo._population}\nPress E";
        }
        else
        {
            _text.text = "CLOSED";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If the Player Enters, grab the main camera, then turn on the billboard
        if (_players.Contains(other.gameObject))
        {
            _lookAtConstraint.SetSources(new List<ConstraintSource>(){
                new ConstraintSource {
                    sourceTransform = Camera.main.transform,
                    weight = 1
                }
            });
            _lookAtConstraint.enabled = true;

            _text.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (_players.Contains(other.gameObject))
        {
            _text.enabled = false;

            _lookAtConstraint.SetSources(new List<ConstraintSource>());
            _lookAtConstraint.enabled = false;
        }        
    }
}
