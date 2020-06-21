using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonEnvironmentHandler : MonoBehaviour
{
    [SerializeField] public GameObject homeWorld;
    [SerializeField] public GameObject monsterMan;
    [SerializeField] private List<AudioClip> screams;
    [SerializeField] public GameObject triggerManager;
    [SerializeField] private PlayerScoreObject _playerScore;
    private Vector3 gravityPosition;
    private float accel = 6.0f;
    private Rigidbody rigid;
    private Animator animationRig;
    private string initialAnimation;
    private string currentAnimation = "Bored";
    private float initialZ;
    private bool dying = false;
    private bool onWorld = false;
    private bool isRunning = false;
    private bool runningRight = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animationRig = GetComponentInChildren<Animator>();
        gravityPosition = homeWorld.transform.position;
        initialZ = gameObject.transform.position.z;

        var rand = Random.Range(0,3);
        initialAnimation = rand == 0 ? "Cheering" : rand == 1 ? "Happy Idle" : "Bored";
        runningRight = rand == 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (triggerManager.GetComponent<TriggerTractorBeam>().isSucking && !dying)
        {
            currentAnimation = "Run";
        }
        else
        {
            currentAnimation = initialAnimation;
        }
        animationRig.Play(currentAnimation);
        if (dying) { rigid.AddForce((gravityPosition - transform.position).normalized * accel); }
        else { rigid.velocity = Vector3.zero; }
        transform.position = new Vector3(transform.position.x, transform.position.y, dying ? transform.position.z : initialZ);
    }

    void OnCollisionEnter(Collision coll)
    {
        onWorld = true;
    }

    void OnTriggerEnter(Collider coll)
    {
        gravityPosition = monsterMan.transform.position;
        accel = 18;
        GetComponent<AudioSource>().clip = screams[Random.Range(0, 4)];
        GetComponent<AudioSource>().Play();
        dying = true;
        currentAnimation = "Run";
        if (coll.tag == "Gulp")
        {
            ++_playerScore._score;
            Destroy(gameObject);
        }
    }
}
