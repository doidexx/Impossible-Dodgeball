using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Ball;
using System;

namespace ID.Core
{
    public class BallSpawner : MonoBehaviour
    {
        [Header("Settings")]
        BallPool ballPool;

        int spawnThisManyBalls, spawnedBalls;
        public int AmountOfBallsToSpawn
        { get { return spawnThisManyBalls; } }

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
            if (timer >= timeBetweenSpawns &&
                !GetComponent<WorldController>().PlayerDown)
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
            GameObject tmpBall = ballPool.GetBallFromPool();
            tmpBall.transform.position = GetNewSpawnPoint();
            tmpBall.SetActive(true);
            spawnedBalls++;
        }

        void DestroyAllExistingBalls()
        {
            BallBehavior[] balls;
            balls = FindObjectsOfType<BallBehavior>();
            foreach (BallBehavior ball in balls)
            {
                if (ball == null) continue;
                ball.gameObject.SetActive(false);
            }
        }

        public void SwitchBallPool(BallPool pool)
        {
            ballPool = pool;
        }

        bool AllBallsHaveSpawned()
        {
            return spawnedBalls >= spawnThisManyBalls;
        }

        Vector3 GetNewSpawnPoint()
        {
            var randomX = UnityEngine.Random.Range(minSPX, maxSPX);
            var randomY = UnityEngine.Random.Range(minSPY, maxSPY);
            return new Vector3(randomX, randomY, depth);
        }
    }
}

