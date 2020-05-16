using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public static bool canMove;
    public static bool jumping;
    public static bool isPlayerHit;
    public static float horMovement;
    public static float verMovement;

    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    [SerializeField] float gravityMultiplier;
    public static float Speed { get; private set; }
    public static float JumpHeight { get; private set; }
    public static float GravityMultiplier { get; private set; }

    public static bool isGrounded;
    public static Rigidbody _rigidbody;
    AnimationController animationController;

    [SerializeField] Joystick joystick;

    Vector3 originalPosition;

    void Start()
    {
        animationController = GetComponent<AnimationController>();
        _rigidbody = GetComponent<Rigidbody>();
        Speed = speed;
        GravityMultiplier = gravityMultiplier;
        JumpHeight = jumpHeight;
        originalPosition = transform.position;
    }

    void Update()
    {
        ProcessInput();
        if (transform.position.y < -5)
            Hit();
        animationController.IsGrounded();
        animationController.PlayRuning();
    }

    void ProcessInput()
    {
        if (isGrounded && canMove)
        {
            if (Input.GetButtonDown("Jump"))
            {
                HandleJump();
            }
            horMovement = joystick.Horizontal;
        }
    }

    public void HandleJump()
    {
        canMove = false;
        animationController.Jump();
    }

    public void Hit()
    {
        canMove = false;
        isPlayerHit = true;
        horMovement = 0;
        AnimationController.animator.enabled = false;
        AnimationController.animator.Rebind();
        FindObjectOfType<UISwitchBehavior>().OnGameOver();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("floor"))
            isGrounded = true;
        if (other.transform.CompareTag("ball"))
            Hit();
    }

    void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("floor"))
            isGrounded = false;
    }

    public void ResetPos()
    {
        isPlayerHit = false;
        horMovement = 0;
        transform.position = originalPosition;
        AnimationController.animator.SetBool("Dancing", false);

        AnimationController.animator.enabled = true;
    }
}