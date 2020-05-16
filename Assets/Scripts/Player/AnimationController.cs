using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] int numberOfDances = 5;
    public static Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayRuning()
    {
        var running = Player_Controller.horMovement;
        animator.SetBool("Moving", running != 0);
        animator.SetFloat("Run", running);
    }

    public void StartDancing()
    {
        Player_Controller.canMove = false;
        Player_Controller.horMovement = 0;
        if (!animator.GetBool("Dancing"))
        {
            var danceIndex = (int)Random.Range(0, numberOfDances);
            animator.SetBool("Dancing", true);
            animator.SetInteger("Dance", danceIndex);
        }
    }

    public void StopDancing()
    {
        Player_Controller.canMove = true;
        animator.SetBool("Dancing", false);
    }

    public void IsGrounded()
    {
        animator.SetBool("Grounded", Player_Controller.isGrounded);
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

    //Animation Event
    public void OnJump()
    {
        PlayerMover.Jump();
    }

    //Animation Event
    public void OnLand()
    {
        Player_Controller.jumping = false;
        Player_Controller.canMove = true;
        animator.ResetTrigger("Jump");
    }
}

