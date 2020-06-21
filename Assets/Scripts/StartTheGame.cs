using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTheGame : MonoBehaviour
{
    [SerializeField] private GameObject gravityPoint;
    [SerializeField] private GameObject homeWorld;
    [SerializeField] private PlanetState planetState;
    [SerializeField] private GameObject BabbyMan;
    [SerializeField, rho.Scene] private string mySceneName;

    // Awake gets called before scene becomes active
    void OnEnable()
    {
        SceneManager.activeSceneChanged += OnActiveSceneChange;
    }

    void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnActiveSceneChange;
    }

    void OnActiveSceneChange(Scene current, Scene next)
    {
        // Only Spawn everything if my scene has just become the active scene
        if (next.name == mySceneName)
        {
            Spawn();
        }
    }

    // Start is called before the first frame update
    void Spawn()
    {
        var spawnPosition = GetComponentInChildren<Transform>();
        var startingPop = planetState.RemainingPeople;

        float degree = 360 / startingPop;

        float currentDegree = 0;

        while(currentDegree < 360)
        {
            var newX = Mathf.Sin(Mathf.Deg2Rad * currentDegree) * 10;
            var newY = Mathf.Cos(Mathf.Deg2Rad * currentDegree) * 10;
            var homey = Instantiate(BabbyMan);
            var curPos = gameObject.transform.position;
            homey.transform.position = new Vector3(curPos.x + newX, curPos.y + newY, curPos.z);
            homey.transform.Rotate(0,180f,currentDegree);
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
