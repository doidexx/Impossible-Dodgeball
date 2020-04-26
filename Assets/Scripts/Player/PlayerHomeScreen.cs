using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ID.Player
{
    public class PlayerHomeScreen : MonoBehaviour
    {
        Vector3 position;
        Quaternion rotation;

        void Start()
        {
            position = transform.position;
            rotation = transform.rotation;
        }

        public void ResetPlayerToNewRound()
        {
            ResetPlayerPosition();
            GetComponent<PlayerController>().CanMove(true);
        }

        public void ResetPlayerToHome()
        {
            ResetPlayerPosition();
            GetComponent<PlayerController>().CanMove(false);
        }

        private void ResetPlayerPosition()
        {
            transform.position = position;
            transform.rotation = rotation;
            GetComponent<Animator>().Rebind();
            GetComponent<CharacterController>().enabled = true;
            GetComponent<Animator>().enabled = true;
        }
    }
}

