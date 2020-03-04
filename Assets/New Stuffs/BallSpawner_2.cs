using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner_2 : MonoBehaviour
{
    WorldScript world;

    [SerializeField]
    GameObject ball;

    [Header("Coordinates")]
    [SerializeField]
    float minX;
    [SerializeField]
    float maxX;
    [SerializeField]
    float minY;
    [SerializeField]
    float maxY;

    public void Spawn()
    {
        var randomX = Random.Range(minX, maxX);
        var randomY = Random.Range(minY, maxY);
        var spawnAt = new Vector3(randomX, randomY, transform.position.z);
        Instantiate(ball, spawnAt, Quaternion.identity);
    }
}
