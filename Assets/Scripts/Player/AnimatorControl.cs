using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ID.Player
{
    public class AnimatorControl : MonoBehaviour
    {
        [SerializeField] [Range(0, 10)] int numberOfDances;
        Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            GetInput();
        }

        void GetInput()
        {
            if (!GetComponent<PlayerController>().allowMove) return;
            var running = GetComponent<PlayerController>().HorizontalMovement;
            animator.SetBool("Moving", running != 0);
            animator.SetFloat("Run", running);
        }

        public void Dance(bool canDance)
        {
            if (canDance)
            {
                if (!animator.GetBool("Dancing"))
                {
                    int danceMove = (int)Random.Range(0, numberOfDances - 1);
                    animator.SetBool("Dancing", canDance);
                    animator.SetInteger("Dance", danceMove);
                }
            }
            else
            {
                animator.SetBool("Dancing", canDance);
            }

        }

        public void Jump()
        {
            animator.SetTrigger("Jump");
        }
    }
}

