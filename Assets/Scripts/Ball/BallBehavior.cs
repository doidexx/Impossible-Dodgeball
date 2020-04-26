using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Core;
using ID.Player;

namespace ID.Ball
{
    public class BallBehavior : MonoBehaviour 
    {
        [SerializeField] BallTarget target;

        [Header("Settings")]
        [SerializeField] float impulseForce;
        [SerializeField] float chasingForce;
        [SerializeField] float lifeTime = 5f;
        [SerializeField] float distanceToChase;

        [Header("Launch Direction Offset")]
        [SerializeField] float horizontalOffset;
        [SerializeField] float verticalOffset;
        float lifeTimer;

        bool collided;

        void Start() 
        {
            target = FindObjectOfType<BallTarget>();
            GetComponent<Rigidbody>().AddForce(GetRandomizedDirection() * impulseForce, ForceMode.Impulse);
        }

        void Update() 
        {
            lifeTimer += Time.deltaTime;
            if (lifeTimer >= lifeTime) DestroyMe();
            
            if (!collided && GetInRange())
                ChaseTarget();
        }

        Vector3 GettargetDirection()
        {
            return (target.transform.position - transform.position).normalized;
        }

        Vector3 GetRandomizedDirection()
        {   
            Vector3 randomizer = target.transform.position + new Vector3 (Random.Range(-horizontalOffset, horizontalOffset), Random.Range(0, verticalOffset), 0);
            return (randomizer - transform.position).normalized;
        }

        void ChaseTarget()
        {
            GetComponent<Rigidbody>().AddForce(GettargetDirection() * chasingForce * Time.deltaTime);
        }

        bool GetInRange() 
        {
            return (Vector3.Distance(target.transform.position, transform.position) < distanceToChase);
        }

        public void DestroyMe()
        {
            Destroy(this.gameObject);
            FindObjectOfType<WorldController>().AddToBallsDodged(false);
        }

        void OnCollisionEnter(Collision other)
        {
            collided = true;
            if (other.transform.CompareTag("Player"))
            {
                FindObjectOfType<WorldController>().AddToBallsDodged(true);
                target.GetComponentInParent<PlayerController>().Hit();
            }
        }
    }
}
