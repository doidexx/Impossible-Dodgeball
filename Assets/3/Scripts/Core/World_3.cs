using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ID.Core
{
    public class World_3 : MonoBehaviour 
    {
        [SerializeField] float timeBetweenBalls; 
        float ballsTimer;
        [SerializeField] int ballsPerRound, ballsDodged;
        int round = 0;
        public int Round { get { return round;} }
        public int BallsDodged { get { return ballsDodged;} }
        
        [SerializeField] float nextRoundIn = 5f;

        bool ballsCanSpawn;
        bool playerDown;

        void Start()
        {
            //Ignore collision between character controller and ball
            Physics.IgnoreLayerCollision(8, 10);
            //Ignore collision between character controller and ragdoll
            Physics.IgnoreLayerCollision(8, 9);
        }

        void Update() 
        {
            BallSpawnerTimeControl();
        }

        void StartNewRound()
        {
            round++;
            ballsCanSpawn = true;
            GetComponent<BallSpawner_3>().SetAmmountToSpawn( 
                GetAmountOfBallsToSpawn());
        }

        public void StartFirstRound()
        {
            round = 0;
            playerDown = false;
            GetComponent<BallSpawner_3>().ResetAmountToSpawn();
            StartCoroutine(WaitUntilNextRound());
        }

        void BallSpawnerTimeControl()
        {
            if (ballsCanSpawn) 
                if (ballsTimer >= timeBetweenBalls)
                {
                    GetComponent<BallSpawner_3>().SpawnNewBall();
                    ballsTimer = 0;
                }
            ballsTimer += Time.deltaTime;
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
            if (ballsDodged == ballsPerRound)
                EndRound(); 
        }

        void EndRound()
        {
            ballsCanSpawn = false;
            StartCoroutine(WaitUntilNextRound());
        }

        IEnumerator WaitUntilNextRound()
        {
            yield return new WaitForSeconds(nextRoundIn);
            StartNewRound();
        }
    }
}
