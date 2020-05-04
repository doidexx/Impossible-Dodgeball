using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Core;
using ID.Player;

namespace ID.Ball
{
    public class BallBehavior : MonoBehaviour
    {
        BallTarget target;

        [Header("Settings")]
        [SerializeField] float impulseForce;
        [SerializeField] float chasingForce;
        [SerializeField] float lifeTime = 4f;
        [SerializeField] float distanceToChase;

        [Header("Launch Direction Offset")]
        [SerializeField] float horizontalOffset;
        [SerializeField] float verticalOffset;
        float lifeTimer;

        bool collided;

        Rigidbody rb;

        void OnEnable()
        {
            lifeTimer = 0;
            target = FindObjectOfType<BallTarget>();
            rb = GetComponent<Rigidbody>();
            GetComponent<TrailRenderer>().emitting = true;
            rb.isKinematic = false;
            rb.AddForce(GetTargetDirectionOffset() * impulseForce, ForceMode.Impulse);
        }

        void Update()
        {
            lifeTimer += Time.deltaTime;
            if (lifeTimer >= lifeTime) 
                gameObject.SetActive(false);

            if (!collided && GetInRange())
                ChaseTarget();
        }

        Vector3 GetTargetDirection()
        {
            return (target.transform.position - transform.position).normalized;
        }

        Vector3 GetTargetDirectionOffset()
        {
            Vector3 randomizer = target.transform.position + new Vector3(Random.Range(-horizontalOffset, horizontalOffset), Random.Range(-verticalOffset / 2, verticalOffset), 0);
            return (randomizer - transform.position).normalized;
        }

        void ChaseTarget()
        {
            rb.AddForce(GetTargetDirection() * chasingForce * Time.deltaTime);
        }

        bool GetInRange()
        {
            return (Vector3.Distance(target.transform.position, transform.position) < distanceToChase);
        }

        void OnDisable()
        {
            rb.isKinematic = true;
            GetComponent<TrailRenderer>().emitting = false;
            FindObjectOfType<WorldController>().AddToDodgedBalls();
        }

        void OnCollisionEnter(Collision other)
        {
            collided = true;
            PlayerController player = other.gameObject.GetComponentInParent<PlayerController>();
            if (player == null) return;
            player.Hit();
        }
    }
}
