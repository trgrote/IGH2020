using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonEnvironmentHandler : MonoBehaviour
{
    [SerializeField] private GameObject homeWorld;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("Run");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetBool("Run", true);
    }
}
