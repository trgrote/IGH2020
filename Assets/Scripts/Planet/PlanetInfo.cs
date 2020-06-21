using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour
{
    [SerializeField] public int _population;

    // Load the state object with current planet data
    public void LoadState(PlanetState state)
    {
        state.RemainingPeople = _population;
    }
}
