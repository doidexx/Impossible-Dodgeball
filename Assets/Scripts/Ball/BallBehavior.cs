using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    Transform target;

    [Header("Settings")]
    [SerializeField] float startingForce;
    [SerializeField] float chasingForce;
    [SerializeField] float lifeTime = 4f;
    [SerializeField] float distanceToChase;
    [Header("Launch Direction Offset")]
    [SerializeField] float horOffset;
    [SerializeField] float verOffset;
    float lifeTimer;

    bool collided;

    Rigidbody _rigidbody;
    GameManager gameManager;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnEnable()
    {
        target = FindObjectOfType<Player_Controller>().transform;
        var direction = GetTargetDirection();
        _rigidbody.AddForce(GetTargetDirection(), ForceMode.Impulse);
    }

    void OnDisable()
    {
        collided = false;
        lifeTimer = 0;
        _rigidbody.velocity = Vector3.zero;
        gameManager.IncreaseScore();
    }

    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeTime)
            gameObject.SetActive(false);

        if (!collided && IsInRange())
            ChaseTarget();
    }

    Vector3 GetTargetDirection()
    {
        var tmpHorOffset = Random.Range(0 ,Player_Controller.horMovement * horOffset);
        //var tmpHorOffset = Random.Range(-horOffset, horOffset);
        var tmpVerOffset = Random.Range(-1, verOffset);
        var target_XOffset = target.position.x + tmpHorOffset;
        var target_YOffset = target.position.y + tmpVerOffset;
        var tmpTarget = new Vector3(target_XOffset, target_YOffset, target.position.z);
        var tmpDirection = (tmpTarget - transform.position).normalized;
        return tmpDirection * startingForce;
    }

    void ChaseTarget()
    {
        var targetDirection = (target.position - transform.position).normalized;
        _rigidbody.AddForce(targetDirection * chasingForce * Time.deltaTime);
    }

    bool IsInRange()
    {
        return (Vector3.Distance(target.transform.position, transform.position) < distanceToChase);
    }

    void OnCollisionEnter(Collision other)
    {
        collided = true;
        GetComponent<AudioSource>().Play();
        if (other.transform.CompareTag("Player"))
        {
            var player = other.transform;
            player.SendMessageUpwards("Hit");
        }
    }
}

