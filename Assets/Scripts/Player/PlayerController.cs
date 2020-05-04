using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.UI;
using ID.Core;

namespace ID.Player
{
    public class PlayerController : MonoBehaviour
    {
        float verticalDirection, horizontalMovement;
        public float HorizontalMovement { get { return horizontalMovement; } }
        
        [SerializeField] [Range(10f, 35f)] float jumpForce, gravity;
        [SerializeField] [Range(10f, 35f)] float movementSpeed;

        [SerializeField] Joystick joystick;

        bool canMove = false;
        public bool allowMove { get { return canMove; } }

        bool touchStart = false;
        bool jumping = false;

        Vector2 positionA, positionB;

        void Update()
        {
            if (canMove)
            {
                GetComponent<CharacterController>().Move(GetDirection() * Time.deltaTime);
                if (transform.position.y <= -5f)
                    Hit();
            }

            GetComponent<Animator>().SetBool("Grounded", GetCharacterGrounded());
        }

        Vector3 GetDirection()
        {
            if (GetCharacterGrounded())
            {
                if (!jumping)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                        JumpTouchButton();

                    if (joystick.Horizontal >= .4f)
                        horizontalMovement = movementSpeed;

                    else if (joystick.Horizontal <= -.4f)
                        horizontalMovement = -movementSpeed;

                    else
                        horizontalMovement = joystick.Horizontal;
                }
            }
            else
                verticalDirection -= gravity * Time.deltaTime;

            return new Vector3(horizontalMovement, verticalDirection, 0);
        }

        public void JumpTouchButton()
        {
            jumping = true;
            GetComponent<AnimatorControl>().Jump();
        }

        //Animation Event
        public void Jump()
        {
            verticalDirection = jumpForce;
        }

        //Animation Event
        public void Land()
        {
            jumping = false;
            GetComponent<Animator>().ResetTrigger("Jump");
        }

        bool GetCharacterGrounded()
        {
            return GetComponent<CharacterController>().isGrounded;
        }

        public void CanMove(bool state)
        {
            canMove = state;
        }

        public void Hit()
        {
            CanMove(false);
            GetComponent<CharacterController>().enabled = false;
            GetComponent<Animator>().enabled = false;
            StartCoroutine(WaitForGameOverScreen());
            FindObjectOfType<WorldController>().PlayerJumpedOff(true);
        }

        IEnumerator WaitForGameOverScreen()
        {
            yield return new WaitForSeconds(3);
            FindObjectOfType<UIScreenSelector>().OpenScreen(5);
        }

        public void Dance(bool d)
        {
            if (d && GetCharacterGrounded())
                CanMove(false);
            else
                CanMove(true);
            GetComponent<AnimatorControl>().Dance(d);
        }
    }
}
