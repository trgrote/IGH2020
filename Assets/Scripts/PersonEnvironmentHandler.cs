using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonEnvironmentHandler : MonoBehaviour
{
    [SerializeField] private GameObject homeWorld;
    private float accel = 3.0f;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().Play("Run");
        rigid.AddForce((homeWorld.transform.position - transform.position).normalized * accel);
        transform.rotation = new Quaternion(0,0.25f,0,0);
    }
}
