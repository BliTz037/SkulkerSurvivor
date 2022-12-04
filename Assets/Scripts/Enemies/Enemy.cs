using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Player;
    private Animator _animator;
    public LayerMask WhatIsGround, WhatIsPlayer;

    //Attack
    public float timeDelayAttack;
    public float Damage;


    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        Agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       ChasePlayer();
    }

    private void ChasePlayer()
    {
        Agent.SetDestination(Player.position);
    }
}
