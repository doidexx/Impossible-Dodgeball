using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cam : MonoBehaviour
{
    WorldScript world;

    [SerializeField]
    Transform player;
    [SerializeField]
    Transform player1;

    [SerializeField]
    Transform mainScreenPos;

    void Start()
    {
        world = FindObjectOfType<WorldScript>();
    }

    void Update()
    {
        var selectedPlayer = (world.selectedSkin == 0) ? player : player1;
        if (world.gameState == 0 || world.gameState == 2)
        {
            transform.position = mainScreenPos.position;
            transform.rotation = mainScreenPos.rotation;
        }
        else
        {
            transform.LookAt(selectedPlayer.position + (Vector3.up * 2));
            transform.position = Vector3.Lerp(transform.position, selectedPlayer.position + (Vector3.back * 6) + (Vector3.up * 2), 0.055f);
        }
    }
}
