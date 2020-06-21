using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTimer : MonoBehaviour
{
    [SerializeField] PlanetState _planetState;
    [SerializeField] so_events.Event _timerOutEvent;
    
    void Start()
    {
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    IEnumerator Countdown()
    {
        while (_planetState.RemainingTime > 0)
        {
            yield return null;
            _planetState.RemainingTime -= Time.deltaTime;
        }
        _timerOutEvent.Raise();
    }
}
