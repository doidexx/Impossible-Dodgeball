using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Spawner : MonoBehaviour
{
    int amountToSpawn;
    public static int spawnedBalls;
    [SerializeField] BallPools[] ballPools;
    BallPools activePool;

    [SerializeField] [Range(0, 1)] float rate = 0.5f;

    public static bool canSpawn = true;

    [Header("Ball Spawn Point")]
    [SerializeField] float minX;
    [SerializeField] float minY;
    [SerializeField] float maxX;
    [SerializeField] float maxY;
    [SerializeField] float depth;

    void Start()
    {
        activePool = ballPools[0];
    }

    void Update()
    {
        if (spawnedBalls < amountToSpawn)
            SpawnNewBall();
    }

    public void SetAmountToSpawn()
    {
        amountToSpawn += GameManager.round * (int)UnityEngine.Random.Range(15, 31);
    }

    public void SpawnNewBall()
    {
        if (!canSpawn) return;
        foreach (Transform ball in activePool.transform)
        {
            if (ball.gameObject.activeInHierarchy) continue;
            ball.transform.position = GetRandomizedPosition();
            ball.gameObject.SetActive(true);
            break;
        }
        canSpawn = false;
        spawnedBalls++;
        StartCoroutine(SpawnRateDelay());
    }

    IEnumerator SpawnRateDelay()
    {
        yield return new WaitForSeconds(rate);
        canSpawn = true;
    }

    public void SwitchActivePool(int index)
    {
        for (int i = 0; i < ballPools.Length; i++)
        {
            if (i != index) continue;
            activePool = ballPools[index];
        }
    }

    private Vector3 GetRandomizedPosition()
    {
        var randomX = Random.Range(minX, maxX);
        var randomY = Random.Range(minY, maxY);
        return new Vector3(randomX, randomY, depth);
    }

    public void OnGameOver()
    {
        canSpawn = false;
        spawnedBalls = 0;
        StopAllCoroutines();
        foreach (Transform ball in activePool.transform)
        {
            if (ball.gameObject.activeInHierarchy)
                ball.gameObject.SetActive(false);
        }
    }
}