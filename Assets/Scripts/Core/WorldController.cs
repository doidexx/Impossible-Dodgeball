using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ID.Player;

namespace ID.Core
{
    public class WorldController : MonoBehaviour
    {
        int ballsDodged;
        int round = 0;
        public int Round { get { return round; } }
        public int BallsDodged { get { return ballsDodged; } }

        public int highRound, highScore;
        bool startCountDown = false;

        // Player State
        bool playerDown;
        public bool PlayerDown { get { return playerDown; } }

        void Start()
        {
            // Ignore collision between character controller and ball
            Physics.IgnoreLayerCollision(8, 10);
            // Ignore collision between character controller and ragdoll
            Physics.IgnoreLayerCollision(8, 9);

            highScore = PlayerPrefs.GetInt("HighScore");
            highRound = PlayerPrefs.GetInt("HighRound");
        }

        void Update()
        {
            if (startCountDown && !playerDown)
                GetComponent<RoundTimer>().canStart = true;
            else
                GetComponent<RoundTimer>().canStart = false;
        }

        public void StartNewRound()
        {
            round++;
            GetComponent<BallSpawner>().SetAmountToSpawn(
                GetAmountOfBallsToSpawn());
            startCountDown = false;
        }

        int GetAmountOfBallsToSpawn()
        {
            return round * (int)UnityEngine.Random.Range(10, 30);
        }

        public void AddToBallsDodged(bool playerHit)
        {
            if (playerDown) return;
            playerDown = playerHit;
            ballsDodged++;
            if (ballsDodged == GetComponent<BallSpawner>().AmountOfBallsToSpawn)
                EndRound();
        }

        void EndRound()
        {
            GetComponent<RoundTimer>().ResetTimer();
            startCountDown = true;
        }

        public void StartFirstRound(bool resetPlayerStates)
        {
            ResetGameStatus();
            FindObjectOfType<PlayerHomeScreen>().ResetPlayerToNewRound();
            EndRound();
        }

        public void HomeScreen()
        {
            ResetGameStatus();
            FindObjectOfType<PlayerHomeScreen>().ResetPlayerToHome();
            startCountDown = false;
        }

        private void ResetGameStatus()
        {
            round = 0;
            ballsDodged = 0;
            playerDown = false;
            GetComponent<BallSpawner>().ResetAmountToSpawn();
            StopAllCoroutines();
        }

        public void UpdateHighScores()
        {
            if (ballsDodged > highScore)
            {
                highScore = ballsDodged;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            if (round > highRound)
            {
                highRound = round;
                PlayerPrefs.SetInt("HighRound", highRound);
            }
        }

        public void PlayerJumpedOff(bool b)
        {
            playerDown = b;
        }
    }
}