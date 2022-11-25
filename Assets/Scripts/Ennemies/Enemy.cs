using UnityEngine;
using UnityEngine.AI;


public enum EnemyState
{
    Chase,
    Attack
}

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Player;
    public LayerMask WhatIsGround, WhatIsPlayer;


    public float AttackRange = 1;
    private bool PlayerInAttackRange;

    //Attack
    public float timeDelayAttack;
    public float Damage;
    public bool AlreadyAttack;

    public EnemyState State = EnemyState.Chase;

    void Awake()
    {
        Player = GameObject.Find("Player").gameObject.transform;
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsPlayer);

        if (PlayerInAttackRange)
            AttackPlayer();
        else
            ChasePlayer();
    }

    private void ChasePlayer()
    {
        Agent.SetDestination(Player.position);
    }

    private void AttackPlayer()
    {
        if (AlreadyAttack)
            return;
        Debug.Log("Attack !");
        AlreadyAttack = true;
        Invoke(nameof(ResetAttack), timeDelayAttack);
    }

    private void ResetAttack()
    {
        AlreadyAttack = false;
    }
}
