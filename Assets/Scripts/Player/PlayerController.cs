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
        [SerializeField] [Range(10f, 35f)] float jumpForce, gravity;
        [SerializeField] [Range(10f, 35f)] float movementSpeed;
        [SerializeField] [Range(0, 10)]int numberOfDances;

        bool canMove = false;
        public bool allowMove { get { return canMove; } }

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
                if (Input.GetKeyDown(KeyCode.Space))
                    GetComponent<AnimatorControl>().Jump();

                horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;
            }
            else 
                verticalDirection -= gravity * Time.deltaTime;

            return new Vector3 (horizontalMovement, verticalDirection, 0);
        }

        //Animation Event
        public void Jump()
        {
            verticalDirection = jumpForce;
        }

        public void Land()
        {
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
            if (d)
            {
                if (!GetComponent<Animator>().GetBool("Dancing") && GetCharacterGrounded())
                {
                    int danceMove = (int)Random.Range(0, numberOfDances - 1);
                    GetComponent<Animator>().SetBool("Dancing", d);
                    GetComponent<Animator>().SetInteger("Dance", danceMove);
                    CanMove(false);
                } 
            }
            else
            {
                    GetComponent<Animator>().SetBool("Dancing", d);
                    CanMove(true);

            }
        }
    }
}
