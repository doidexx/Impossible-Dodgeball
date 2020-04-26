using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenBallBehavior : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(transform.right * -20f * Time.deltaTime);
    }
}
