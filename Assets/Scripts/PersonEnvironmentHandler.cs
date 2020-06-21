using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonEnvironmentHandler : MonoBehaviour
{
    [SerializeField] public GameObject homeWorld;
    [SerializeField] public GameObject monsterMan;
    [SerializeField] private List<AudioClip> screams;
    private Vector3 gravityPosition;
    private float accel = 9.0f;
    private Rigidbody rigid;
    private Animator animationRig;
    private string currentAnimation = "Bored";
    private float initialZ;
    private bool dying = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animationRig = GetComponentInChildren<Animator>();
        gravityPosition = homeWorld.transform.position;
        initialZ = gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        animationRig.Play(currentAnimation);
        rigid.AddForce((gravityPosition - transform.position).normalized * accel);
        transform.rotation = new Quaternion(0,0.25f,0,0);
        transform.position = new Vector3(transform.position.x, transform.position.y, dying ? transform.position.z : initialZ);
    }

    void OnTriggerEnter(Collider coll)
    {
        gravityPosition = monsterMan.transform.position;
        accel = 18;
        GetComponent<AudioSource>().clip = screams[Random.Range(0, 3)];
        GetComponent<AudioSource>().Play();
        dying = true;
        currentAnimation = "Run";
        if (coll.tag == "Gulp")
        {
            Destroy(gameObject);
        }
    }
}
