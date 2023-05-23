using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private static readonly int ToWalkHash = Animator.StringToHash("ToWalk");
    private static readonly int ToRunHash = Animator.StringToHash("ToRun");
    private static readonly int ToAttackHash = Animator.StringToHash("ToAttack");

    [SerializeField] private Transform player;

    private NavMeshAgent _agent;

    private float visionRange = 3f;
    private float attackRange = 1.5f;

    private bool playerInVisionRange;
    private bool playerInAttackRange;

    [SerializeField] private LayerMask playerLayer;

    // Patrulla
    [SerializeField] private Transform[] waypoints;
    private int totalWaypoints;
    private int nextPoint;

    // Ataque
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    private float timeBetweenAttacks = 5f;
    private bool canAttack;
    [SerializeField] private float upAttackForce = 15f;
    [SerializeField] private float forwardAttackForce = 18f;

    Animator anim;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }

    private void Start()
    {
        totalWaypoints = waypoints.Length;
        nextPoint = 1;
        canAttack = true;
    }

    private void Update()
    {
  
        Vector3 pos = transform.position;
        playerInVisionRange = Physics.CheckSphere(pos, visionRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(pos, attackRange, playerLayer);

        if (!playerInVisionRange && !playerInAttackRange)
        {
            Patrol();
        }

        if (playerInVisionRange && !playerInAttackRange)
        {
            Chase();
        }

        if (playerInVisionRange && playerInAttackRange)
        {

            Attack();
        }
    }

    private void Patrol()
    {
        if (Vector3.Distance(transform.position,waypoints[nextPoint].position) < 2.5f)
        {
            anim.SetBool(ToWalkHash, true);

            nextPoint++;
            if (nextPoint == totalWaypoints)
            {
                nextPoint = 0;
            }
            transform.LookAt(waypoints[nextPoint].position);
        }
        _agent.SetDestination(waypoints[nextPoint].position);
    }

    private void Chase()
    {
        anim.SetBool(ToRunHash, true);

        _agent.SetDestination(player.position);
        transform.LookAt(player);
    }

    private void Attack()
    {
        _agent.SetDestination(transform.position);
        anim.SetTrigger(ToAttackHash);

        if (canAttack)
        {
            Debug.Log("attack");
            canAttack = false;
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }

    private void OnDrawGizmos()
    {
        // Esfera de visión
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        // Esfera de ataque
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}