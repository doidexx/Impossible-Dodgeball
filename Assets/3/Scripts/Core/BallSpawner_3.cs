using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Ball;

namespace ID.Core
{
    public class BallSpawner_3 : MonoBehaviour
    {
        int spawnThisManyBalls, spawnedBalls;

        [SerializeField] float minX, maxX, minY, maxY, depth;

        [SerializeField] GameObject ballPrefab;

        public void SetAmmountToSpawn(int amount)
        {
            spawnThisManyBalls += amount;
        }

        public void ResetAmountToSpawn()
        {
            spawnThisManyBalls = 0;
        }

        public void SpawnNewBall()
        {
            if (spawnedBalls >= spawnThisManyBalls) return;
            Instantiate (ballPrefab, GetNewSpawnPoint(), Quaternion.identity);
            spawnedBalls++;
        }

        Vector3 GetNewSpawnPoint()
        {
            var randomX = Random.Range(minX, maxX);
            var randomY = Random.Range(minY, maxY);
            return new Vector3(randomX, randomY, depth);
        }
    }
}

