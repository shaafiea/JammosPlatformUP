using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
