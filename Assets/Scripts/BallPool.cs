using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Ball;

public class BallPool : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] int amountToPreSpawn = 30;
    List<GameObject> pool;

    void Awake()
    {
        if (!ball.GetComponent<BallBehavior>()) 
        {
            Debug.LogError("The gameobject in " + name + " is not a ball");
            Debug.Break();
        }
        pool = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPreSpawn; i++)
        {
            tmp = Instantiate(ball);
            tmp.transform.SetParent(this.transform);
            tmp.SetActive(false);
            pool.Add(tmp);
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
