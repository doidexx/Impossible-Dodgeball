using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ID.Player
{
    public class AnimatorControl : MonoBehaviour
    {
        Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            if (!GetComponent<PlayerController>().allowMove) return;
            var running = Input.GetAxis("Horizontal");
            animator.SetBool("Moving", running != 0);
            animator.SetFloat("Run", running);
        }

        public void Jump()
        {
            animator.SetTrigger("Jump");
        }
    }
}

