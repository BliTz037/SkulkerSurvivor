using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Player;
    private Animator _animator;
    public LayerMask WhatIsGround, WhatIsPlayer;

    public float Damage;

    private float _damageDelay = 0f;


    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        Agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StateManager.Instance().CurrentState != State.Game)
        {
            _animator.SetBool("IsRunning", false);
            Agent.isStopped = true;
            return;
        }
        else
        {
            Agent.isStopped = false;
            _animator.SetBool("IsRunning", true);
        }     
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        Agent.SetDestination(Player.position);
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time > _damageDelay)
            {
                _damageDelay = Time.time + 1f;
                collision.gameObject.GetComponent<PlayerController>().TakeDamage(Damage);
            }
        }
    }
}
