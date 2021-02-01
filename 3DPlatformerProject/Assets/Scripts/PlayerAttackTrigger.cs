using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour
{
    [SerializeField] private EnemyAI enemyAI;


    //Trigger Event to call enemy being attacked
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //If the enemy has been attacked take away their life

            //Only take the life of the enemy that has been hit
                enemyAI = other.gameObject.GetComponent<EnemyAI>();
                enemyAI.EnemyLoseHealth();

         }

    }
 }
