using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class SlimeAI : MonoBehaviour
{
    Animator animator;      // the animator
    NavMeshAgent slimeAgent;    // the slimeAgentv mesh agent

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    private float patrol_time;

    private int waypoint;

    public float waiting_time = 1f;

    public Transform[] patrolWayPoints;

    //Animation State Variables

    public float sightRange, attackRange;
    public bool playerInSightRange, playerIslimeAgentttackRange;


    //Patrolling
    public Vector3 wayPoints;
    private bool wayPointSet;
    public float wayPointRange;

    //Attacking
    public float timeBetweeslimeAgentttacks;
    private bool alreadyAttacked;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        slimeAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerIslimeAgentttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerIslimeAgentttackRange) Patrol();
        if (playerInSightRange && !playerIslimeAgentttackRange) ChasePlayer();
        if (!playerInSightRange && playerIslimeAgentttackRange) AttackPlayer();
    }
    private void Patrol()
    {
        slimeAgent.isStopped = false;
        if (slimeAgent.remainingDistance < slimeAgent.stoppingDistance)
        {
            patrol_time += Time.deltaTime;
            if (patrol_time >= waiting_time)
            {
                if (waypoint == patrolWayPoints.Length - 1)
                {
                    waypoint = 0;
                }
                else
                {
                    waypoint++;
                }
                patrol_time = 0f;
            }
        }
        else
        {
            patrol_time = 0f;
        }
        slimeAgent.destination = patrolWayPoints[waypoint].position;
    }
    private void AttackPlayer()
    {
        slimeAgent.SetDestination(player.position);
    }

    private void ChasePlayer()
    {
        slimeAgent.SetDestination(transform.position);

        transform.LookAt(player);
    }
}
