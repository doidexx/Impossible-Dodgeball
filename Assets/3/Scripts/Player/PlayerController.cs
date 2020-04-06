using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.UI;

namespace ID.Player
{
    public class PlayerController : MonoBehaviour 
    {
        float verticalDirection, horizontalMovement;
        [SerializeField] [Range(10f, 35f)] float jumpForce, gravity; 
        [SerializeField] [Range(10f, 35f)] float speed;

        bool canMove = true;

        void Update()
        {
            if (canMove)
                GetComponent<CharacterController>().Move(GetDirection() * Time.deltaTime);
        }

        Vector3 GetDirection()
        {
            if (GetCharacterGrounded())
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    verticalDirection = jumpForce;
                    GetComponent<AnimatorControl>().Jump();
                }
                horizontalMovement = Input.GetAxis("Horizontal") * speed;
            }
            verticalDirection -= gravity * Time.deltaTime;

            return new Vector3 (horizontalMovement, verticalDirection, 0);
        }

        bool GetCharacterGrounded()
        {
            return GetComponent<CharacterController>().isGrounded;
        }

        public void Hit() 
        {
            canMove = false;
            GetComponent<Animator>().enabled = false;
            FindObjectOfType<UIScreensController>().OpenGameOverScreen();
        }
    }
}
