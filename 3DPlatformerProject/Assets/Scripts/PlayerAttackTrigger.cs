using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This code was edited by me to help with knockback and call a function from the game manager
/// which references the player controller.
/// https://www.youtube.com/watch?v=MwojdoYu0lE&t=840s&ab_channel=gamesplusjames
/// </summary>
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
