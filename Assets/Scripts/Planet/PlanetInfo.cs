using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour
{
    [SerializeField] PlanetState _currentPlanetState;
    [SerializeField] so_events.EventListener _unloadWorldCompleteHandler;

    [Header("Planet Info")]
    [SerializeField] public int _population;

    [Header("Events")]
    [SerializeField] so_events.Event _loadWorldSceneEvent;

    // Load the state object with current planet data
    private void LoadState(PlanetState state)
    {
        state.RemainingPeople = _population;
    }

    private void LoadFromState(PlanetState state)
    {
        _population = state.RemainingPeople;
    }

    public void Enter()
    {
        // Regsiter Self to Update Info after return to match new state data
        _unloadWorldCompleteHandler.enabled = true;

        // Load PlanetInfo into planet state
        LoadState(_currentPlanetState);
        _loadWorldSceneEvent.Raise();        
    }

    public void OnUloadWorldComplete()
    {
        LoadFromState(_currentPlanetState);
        _unloadWorldCompleteHandler.enabled = false;
    }
}
