using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Ball;

public class BallPools : MonoBehaviour
{
    public BallPool poolName;
    [SerializeField] BallBehavior ball;
    [SerializeField] int amountToPreSpawn = 30;
    List<GameObject> pool;

    void Awake()
    {
        if (ball == null) return;
        pool = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPreSpawn; i++)
        {
            tmp = Instantiate(ball.gameObject) as GameObject;
            tmp.transform.SetParent(this.transform);
            tmp.SetActive(false);
            pool.Add(tmp.gameObject);
        }
    }

    public GameObject GetBallFromPool()
    {
        foreach (GameObject ball in pool)
            if (!ball.activeInHierarchy)
                return ball;
        return null;
    }
}
