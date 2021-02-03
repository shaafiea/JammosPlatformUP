using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This code was edited by me to help with knockback and call a function from the game manager
/// which references the player controller.
/// https://www.youtube.com/watch?v=MwojdoYu0lE&t=840s&ab_channel=gamesplusjames
/// </summary>
public class EnemyAttackTrigger : MonoBehaviour
{
    [SerializeField] private MyGameManager gameManager;
    [SerializeField] private PlayerController player;


    //Trigger Event for if the Enemy Attacks the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Call PlayerController to activate KnockBack
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            //Debug.Log(hitDirection);

            //Activate invinciblity


            //Call gameManager to take away a Life
            FindObjectOfType<MyGameManager>().EnemyAttack(hitDirection);

        }

    }
}
