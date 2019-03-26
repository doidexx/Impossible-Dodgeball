using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScreenBallBehavior : MonoBehaviour
{
    WorldScript world;

    Vector3 firstposition;

    void Start()
    {
        world = FindObjectOfType<WorldScript>();
        firstposition = transform.position;
    }

    void FixedUpdate()
    {
        if (world.gameState == 0 || world.gameState == 2)
        {
            transform.position += Vector3.down * 0.5f;
            if (transform.position.y < 0)
            {
                transform.position = new Vector3(firstposition.x, Random.Range(30, 100), firstposition.z);
            }
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
