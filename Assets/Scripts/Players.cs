using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Players : MonoBehaviour
{
    WorldScript world;

    [SerializeField]
    Transform mainScreen;

    public Animator playerAn;

    NavMeshAgent playerNav;

    Vector3 positioner;
    Vector3 centerPos;
    Quaternion initialRotation;

    bool controlActive;

    bool hit;
    public bool Hit { get { return hit; } }

    void Start()
    {
        world = FindObjectOfType<WorldScript>();
        hit = false;
        controlActive = true;
        centerPos = transform.position;
        positioner = transform.position;
        initialRotation = transform.rotation;
        playerNav = GetComponent<NavMeshAgent>();
        playerAn = GetComponent<Animator>();
    }

    void Update()
    {
        if (world.gameState == 1)
        {
            Controller();
        }
        else
        {
            playerAn.enabled = true;
            playerAn.SetInteger("state", 1);
            transform.position = mainScreen.position;
            transform.rotation = mainScreen.rotation;
        }
    }

    void FixedUpdate()
    {
        //Setting a new position for the player character to move to.
        playerNav.SetDestination(positioner);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<Animator>().enabled = false;
            controlActive = false;
            hit = true;
        }
    }

    void Controller()
    {
        if (controlActive && playerAn.GetInteger("state") != 2)
        {
            if (Input.GetKey(KeyCode.A))
            {
                playerAn.SetInteger("state", 1);
                positioner = transform.position + Vector3.left;
            }

            if (Input.GetKeyUp(KeyCode.A)) { playerAn.SetInteger("state", 0); }

            if (Input.GetKey(KeyCode.D))
            {
                playerAn.SetInteger("state", 1);
                positioner = transform.position + Vector3.right;
            }

            if (Input.GetKeyUp(KeyCode.D)) { playerAn.SetInteger("state", 0); }
        }
    }

    public void RoundReady()
    {
        playerAn.SetInteger("state", 0);
        playerAn.enabled = true;
        transform.position = centerPos;
        positioner = centerPos;
        transform.rotation = initialRotation;
        GetComponent<Collider>().enabled = true;
        controlActive = true;
        hit = false;
    }
}
