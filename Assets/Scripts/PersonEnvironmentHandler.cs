using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonEnvironmentHandler : MonoBehaviour
{
    [SerializeField] private GameObject homeWorld;
    [SerializeField] private GameObject monsterMan;
    [SerializeField] private List<AudioClip> screams;
    private Vector3 gravityPosition;
    private float accel = 9.0f;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        gravityPosition = homeWorld.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().Play("Run");
        rigid.AddForce((gravityPosition - transform.position).normalized * accel);
        transform.rotation = new Quaternion(0,0.25f,0,0);
    }

    void OnTriggerEnter(Collider coll)
    {
        gravityPosition = monsterMan.transform.position;
        accel = 18;
        GetComponent<AudioSource>().clip = screams[Random.Range(0, 3)];
        GetComponent<AudioSource>().Play();
        Debug.Log("ENTER");
    }

    void OnTriggerExit(Collider coll)
    {
        Debug.Log("EXIT");
    }
}
