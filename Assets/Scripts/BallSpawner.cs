using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BallSpawner : MonoBehaviour
{
    WorldScript world;

    [SerializeField]
    GameObject ball;

    public int howManyBalls;
    
    void Start()
    {
        world = FindObjectOfType<WorldScript>();
    }

    public void RoundReady()
    {
        if (world.gameState != 0)
        {
            SpawnBalls();
        }
    }

    void SpawnBalls()
    {
        howManyBalls = (howManyBalls > 40) ? 40 : howManyBalls;
        for (int i = 0; i < howManyBalls; i++)
        {
            GameObject newball;
            newball = Instantiate(ball, new Vector3(Random.Range(-200, 200), Random.Range(50, 200), ball.transform.position.z), Quaternion.identity);
            newball.SetActive(true);
        }
    }
}
