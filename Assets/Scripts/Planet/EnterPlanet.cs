using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnterPlanet : MonoBehaviour
{
    [SerializeField] rho.RuntimeGameObjectSet _planets;

    public void EnterCurrentPlanet(InputAction.CallbackContext context)
    {
        // If this input is on up, then grab the first intersecting planet and enter it
        _intersectingPlanets.Where((_) => !context.canceled).Take(1).ToList().ForEach(p => {
            p.Enter();
        });

        _intersectingPlanets.Clear();
    }

    List<PlanetInfo> _intersectingPlanets = new List<PlanetInfo>();

    void OnTriggerEnter(Collider other)
    {
        if (_planets.Contains(other.gameObject))
        {
            var planetInfo = other.GetComponent<PlanetInfo>();
            if (planetInfo && planetInfo.CanEnter())
            {
                _intersectingPlanets.Add(planetInfo);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (_planets.Contains(other.gameObject))
        {
            var planetInfo = other.GetComponent<PlanetInfo>();
            if (planetInfo)
            {
                _intersectingPlanets.Remove(planetInfo);
            }
        }
    }
}
