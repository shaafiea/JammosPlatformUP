using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemyattackBox;

    //During Animations Turn on the GameObject

    public void EnableAttack()
    {
        //Make GameObject Active
        enemyattackBox.SetActive(true);
    }

    public void DisableAttack()
    {
        //Disable GameObject
        enemyattackBox.SetActive(false);
    }



}
