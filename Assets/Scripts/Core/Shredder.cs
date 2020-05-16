using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var tmp = other.GetComponent<BallBehavior>();
        if (tmp != null)
            tmp.gameObject.SetActive(false);
    }
}
