using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ID.Core;
using ID.Player;

namespace ID.Ball
{
    public class BallBehavior_3 : MonoBehaviour 
    {
        [SerializeField] float impulseForce, chasingForce;
        [SerializeField] float timeToDestroyBall = 5f;
        [SerializeField] float distanceToChase;
        float timer;
        PlayerController target;

        static bool collided;

        void Start() 
        {
            target = FindObjectOfType<PlayerController>();
            GetComponent<Rigidbody>().AddForce(GetRandomizedDirection() * impulseForce, ForceMode.Impulse);
        }

        void Update() 
        {
            timer += Time.deltaTime;
            if (timer >= timeToDestroyBall) DestroyMe();

            if (!collided && GetInRange())
                Chasetarget();
        }

        Vector3 GettargetDirection()
        {
            return (target.transform.position - transform.position).normalized;
        }

        Vector3 GetRandomizedDirection()
        {   
            Vector3 randomizer = target.transform.position + new Vector3 (Random.Range(-10, 10), Random.Range(0, 5), 0);
            return (randomizer - transform.position).normalized;
        }

        void Chasetarget()
        {
            GetComponent<Rigidbody>().AddForce(GettargetDirection() * chasingForce);
        }

        bool GetInRange() 
        {
            return (Vector3.Distance(target.transform.position, transform.position) < distanceToChase);
        }

        public void DestroyMe()
        {
            Destroy(this.gameObject);
            FindObjectOfType<World_3>().AddToBallsDodged(false);
        }

        void OnCollisionEnter(Collision other)
        {
            collided = true;
            if (other.transform.CompareTag("Player"))
            {
                FindObjectOfType<World_3>().AddToBallsDodged(true);
                target.Hit();
            }
        }
    }
}
