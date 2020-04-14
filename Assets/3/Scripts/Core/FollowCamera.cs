using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothness = 0.125f;
    [SerializeField] float verticalPosition;

    void LateUpdate()
    {
        var playerPos = new Vector3 (player.position.x, verticalPosition, player.position.z);
        transform.position = Vector3.Lerp(transform.position, playerPos, smoothness * Time.deltaTime);
    }
}
