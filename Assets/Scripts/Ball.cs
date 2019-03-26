using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    WorldScript world;

    [SerializeField]
    GameObject fire;

    [SerializeField]
    GameObject floor;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject player1;

    [SerializeField]
    float ballSpeed;

    Vector3 direction;
    public Vector3 Direction { get { return direction; } }

    Rigidbody ballRigidboy;

    AudioSource bounce;

    float left, right, floorWidth;

    void Start()
    {
        world = FindObjectOfType<WorldScript>();

        bounce = GetComponent<AudioSource>();
        //Assign rigidbody
        ballRigidboy = GetComponent<Rigidbody>();
        //get floor width to randomly shoot the ball on it
        floorWidth = floor.transform.lossyScale.x;
        left = transform.position.x - (floorWidth / 2);
        right = transform.position.x + (floorWidth / 2);
        //Give the ball a direction
        direction = Vector3.Normalize(floor.transform.position - new Vector3(Random.Range(left, right), Random.Range(transform.position.y + 2f, transform.position.y - 0.9f), transform.position.z));
        transform.LookAt(direction);
    }

    void FixedUpdate()
    {
        //Give the ball a force towards that direction
        ballRigidboy.AddForce(direction * ballSpeed);
        //Destroy unessesary balls
        if (transform.position.y < 0 || transform.position.z < -20 || ((transform.position.x > 30 
            || transform.position.x < -30) && transform.position.z < 20) || world.gameState == 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == floor || other.gameObject == player || other.gameObject == player1)
        {
            fire.SetActive(false);
        }
        bounce.Play();
    }
}
