using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLights : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform player1;
    
    void FixedUpdate()
    {
        if (player.gameObject.activeSelf == true)
        {
            transform.LookAt(player.position + (Vector3.up * 2));
        }
        else
        {
            transform.LookAt(player1.position + (Vector3.up * 2));
        }
    }
}
