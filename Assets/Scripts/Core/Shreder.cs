using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Ball;

namespace ID.Core
{
    public class Shreder : MonoBehaviour 
    {
        void OnCollisionEnter(Collision other)
        {
            BallBehavior ball = other.transform.GetComponent<BallBehavior>();
            if (ball != null)
                ball.gameObject.SetActive(false);
        }
    }
}
