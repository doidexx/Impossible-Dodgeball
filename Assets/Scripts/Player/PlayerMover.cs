using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    void FixedUpdate()
    {
        Move();
        GetVerticalMovement();
    }

    public void Move()
    {
        var direction = GetDirection();
        Player_Controller._rigidbody.velocity = direction;
    }

    Vector3 GetDirection()
    {
        var x = Player_Controller.horMovement * Player_Controller.Speed;
        var y = Player_Controller.verMovement;
        var z = 0f;
        return new Vector3(x, y, z);
    }

    void GetVerticalMovement()
    {
        if (Player_Controller.isGrounded)
            Player_Controller.verMovement = 0;
        else
            Player_Controller.verMovement += Physics.gravity.y * Player_Controller.GravityMultiplier * Time.deltaTime;
    }

    public static void Jump()
    {
        Player_Controller.isGrounded = false;
        Player_Controller.verMovement = Player_Controller.JumpHeight;
    }
}