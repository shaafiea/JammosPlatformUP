using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]private Animator anim;      // the animator
    [SerializeField]private NavMeshAgent enemyAI;    // the nav mesh agent

    [SerializeField]private int enemyhealth = 1;

    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;

    public Transform player;

    [SerializeField]private float patrol_time;
    [SerializeField]private int waypoint;
    public float waiting_time = 1f;
    public Transform[] patrolWayPoints;


    //enum AIState {Patrol, Attack, Chase};

    //AIState state;
    // Use this for initialization
    void Start()
    {
        enemyAI = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        //state = AIState.Patrol;
    }

    // Update is called once per frame
    void Update()
    {
        // Detect the player
        float targetdist = Vector3.Distance(player.transform.position,
            transform.position);

        anim.SetFloat("TargetDist", targetdist);
        

        //Check for the current state the enemy is in
       AnimatorStateInfo asi = anim.GetCurrentAnimatorStateInfo(0);

        if (asi.IsName("Patrol"))
        {
            Patrol();
        }

        if (asi.IsName("Attack"))
        {
           Attack();
        }

        if (asi.IsName("Chase"))
        {
            Chase();
        }

        if (asi.IsName("Die"))
        {
            EnemyLoseHealth();
        }
        /*switch (state)
        {
            case AIState.Patrol:
                Patrol();
                break;
            case AIState.Attack:
                Attack();
                break;
            case AIState.Chase:
                Chase();
                break;
        }*/

    }

    // The player has attacked the enemy then the enemy dies
    public void EnemyLoseHealth()
    {
        enemyhealth = enemyhealth - 1;
        if (enemyhealth <= 0)
        {
            chaseSpeed = 0;
            patrolSpeed = 0;
            anim.SetTrigger("IsDead");
            Destroy(gameObject, 2f);

        }
    }

    //Set Zombie to stay in position and Attack
    public void Attack()
    {
        enemyAI.isStopped = true;
        enemyAI.velocity = Vector3.zero;
    }

    //Set the Zombie to walk in his set waypoints given to himw
    public void Patrol()
    {
        enemyAI.isStopped = false;
        enemyAI.speed = patrolSpeed;
        if (enemyAI.remainingDistance <= enemyAI.stoppingDistance)
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
            //Reset Timer if not near destination
            patrol_time = 0f;
        }
        enemyAI.destination = patrolWayPoints[waypoint].position;
    }


    //Set zombie to chase the player
    public void Chase()
    {
        enemyAI.isStopped = false;

        enemyAI.destination = player.transform.position;
        enemyAI.speed = chaseSpeed;
    }

}
