using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Ball;

namespace ID.Core
{
    public class BallSpawner_3 : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] GameObject ballPrefab; //Serialized for Debug
        int spawnThisManyBalls, spawnedBalls;
        public int AmountOfBallsToSpawn { get { return spawnThisManyBalls; } }

        [SerializeField] float timeBetweenSpawns = 2f;
        float timer;

        [Header("Spawn Point Randomizer Values")]
        [SerializeField] float minSPX;
        [SerializeField] float maxSPX;
        [SerializeField] float minSPY;
        [SerializeField] float maxSPY;
        [SerializeField] float depth;


        void Update()
        {
            SpawnTimerControl();
        }

        private void SpawnTimerControl()
        {
            if (timer >= timeBetweenSpawns && !GetComponent<World_3>().PlayerDown)
            {
                if (!AllBallsHaveSpawned())
                    SpawnNewBall();
                timer = 0;
            }
            timer += Time.deltaTime;
        }

        public void SetAmountToSpawn(int amount)
        {
            spawnThisManyBalls += amount;
        }

        public void ResetAmountToSpawn()
        {
            spawnThisManyBalls = 0;
            spawnedBalls = 0;
            DestroyAllExistingBalls();
        }

        public void SpawnNewBall()
        {
            if (AllBallsHaveSpawned()) return;
            Instantiate (ballPrefab, GetNewSpawnPoint(), Quaternion.identity);
            spawnedBalls++;
        }

        void DestroyAllExistingBalls()
        {
            BallBehavior_3[] balls;
            balls = FindObjectsOfType<BallBehavior_3>();
            foreach (BallBehavior_3 ball in balls)
            {
                if (ball == null) continue;
                Destroy(ball.gameObject);
            }
        }

        public void ChangePrefabTo(GameObject ball)
        { 
            ballPrefab = ball;
        }

        bool AllBallsHaveSpawned()
        { 
            return spawnedBalls >= spawnThisManyBalls;
        }

        Vector3 GetNewSpawnPoint()
        {
            var randomX = Random.Range(minSPX, maxSPX);
            var randomY = Random.Range(minSPY, maxSPY);
            return new Vector3(randomX, randomY, depth);
        }
    }
}

