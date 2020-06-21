using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class WritePlanetRemaining : MonoBehaviour
{
    [SerializeField] PlanetState _planetState;
    Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = $"Pop. Left: {_planetState.RemainingPeople}\nTime Left: {(int)_planetState.RemainingTime}";
    }
}
