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

        BallSpawner ballSpawner;

        void Start()
        {
            // Ignore collision between character controller and ball
            Physics.IgnoreLayerCollision(8, 10);
            // Ignore collision between character controller and ragdoll
            Physics.IgnoreLayerCollision(8, 9);

            ballSpawner = GetComponent<BallSpawner>();

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
            ballSpawner.SetAmountToSpawn(
                GetAmountOfBallsToSpawn());
            startCountDown = false;
        }

        int GetAmountOfBallsToSpawn()
        {
            return round * (int)Random.Range(15, 30);
        }

        public void AddToDodgedBalls()
        {
            if (playerDown || round == 0) return;
            ballsDodged++;
            if (ballsDodged == ballSpawner.AmountOfBallsToSpawn)
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
            FindObjectOfType<ResettingHandler>().ResetPlayerToNewRound();
            EndRound();
        }

        public void HomeScreen()
        {
            ResetGameStatus();
            FindObjectOfType<Fireworks>().Activate(false);
            GetComponent<RoundTimer>().ResetTimer();
            FindObjectOfType<ResettingHandler>().ResetPlayerToHome();
            startCountDown = false;
        }

        private void ResetGameStatus()
        {
            round = 0;
            ballsDodged = 0;
            playerDown = false;
            ballSpawner.ResetAmountToSpawn();
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