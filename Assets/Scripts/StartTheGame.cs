using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheGame : MonoBehaviour
{
    [SerializeField] private GameObject gravityPoint;
    [SerializeField] private GameObject homeWorld;
    [SerializeField] private PlanetState planetState;
    [SerializeField] private GameObject BabbyMan;
    // Start is called before the first frame update
    void Start()
    {
        var spawnPosition = GetComponentInChildren<Transform>();
        var startingPop = planetState.RemainingPeople;

        float degree = 360 / startingPop;

        float currentDegree = 0;

        while(currentDegree < 360)
        {
            var newX = Mathf.Sin(Mathf.Deg2Rad * currentDegree) * 11;
            var newY = Mathf.Cos(Mathf.Deg2Rad * currentDegree) * 11;
            var homey = Instantiate(BabbyMan);
            var curPos = gameObject.transform.position;
            homey.transform.position = new Vector3(curPos.x + newX, curPos.y + newY, curPos.z);
            homey.GetComponent<PersonEnvironmentHandler>().homeWorld = homeWorld;
            homey.GetComponent<PersonEnvironmentHandler>().monsterMan = gravityPoint;
            currentDegree += degree;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
