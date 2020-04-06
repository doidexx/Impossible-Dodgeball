using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Ball;

namespace ID.Core
{
    public class Shreder_3 : MonoBehaviour 
    {
        void OnCollisionEnter(Collision other)
        {
            BallBehavior_3 BB = other.transform.GetComponent<BallBehavior_3>();
            if (BB != null)
            {
                BB.DestroyMe();
            }
        }
    }
}
