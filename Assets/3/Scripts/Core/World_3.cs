using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Player;

namespace ID.Core
{
    public class World_3 : MonoBehaviour 
    {
        int ballsDodged;
        int round = 0;
        public int Round { get { return round;} }
        public int BallsDodged { get { return ballsDodged;} }
        
        [SerializeField] float nextRoundIn = 5f;

        bool ballsCanSpawn;
        bool playerDown;
        public bool PlayerDown { get { return playerDown; } }

        void Start()
        {
            //Ignore collision between character controller and ball
            Physics.IgnoreLayerCollision(8, 10);
            //Ignore collision between character controller and ragdoll
            Physics.IgnoreLayerCollision(8, 9);
        }

        void StartNewRound()
        {
            round++;
            GetComponent<BallSpawner_3>().SetAmountToSpawn( 
                GetAmountOfBallsToSpawn());
        }

        int GetAmountOfBallsToSpawn()
        {
            return round * (int)Random.Range(10, 30);
        }

        public void AddToBallsDodged(bool playerHit)
        {
            if (playerDown) return;
            playerDown = playerHit;
            ballsDodged++;
            if (ballsDodged == GetComponent<BallSpawner_3>().AmountOfBallsToSpawn)
                EndRound(); 
        }

        void EndRound()
        {
            StartCoroutine(WaitUntilNextRound());
        }

        IEnumerator WaitUntilNextRound()
        {
            yield return new WaitForSeconds(nextRoundIn);
            StartNewRound();
        }

        public void StartFirstRound(bool resetPlayerStates)
        {
            ResetGameStatus();
            FindObjectOfType<PlayerHomeScreen>().ResetPlayerToRound();
            EndRound();
        }

        public void HomeScreen()
        {
            ResetGameStatus();
            FindObjectOfType<PlayerHomeScreen>().ResetPlayerToHome();
        }

        private void ResetGameStatus()
        {
            round = 0;
            ballsDodged = 0;
            playerDown = false;
            GetComponent<BallSpawner_3>().ResetAmountToSpawn();
            StopAllCoroutines();
        }

    }
}
