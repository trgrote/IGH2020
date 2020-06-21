using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPlanet : MonoBehaviour
{
    [SerializeField] so_events.Event _loadWorldSceneEvent;

    public void Enter(PlanetInfo planetInfo, PlanetState planetState)
    {
        // Load PlanetInfo into planet state
        planetInfo.LoadState(planetState);
        _loadWorldSceneEvent.Raise();
    }
}
