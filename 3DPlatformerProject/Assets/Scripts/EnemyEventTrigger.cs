using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This script was created by me
///  I learnt how to create this script by watching
///  university material (Animating swordsman) 
///  To have a understanding of animation events
/// </summary>
public class EnemyEventTrigger : MonoBehaviour
{
    public AudioSource enemyAttack;
    public AudioSource punchAttack;
    public AudioSource walksound;
    [SerializeField] private GameObject enemyattackBox;

    //During Animations Turn on the GameObject

    public void EnableAttack()
    {
        //Make GameObject Active
        enemyattackBox.SetActive(true);
        punchAttack.Play();
    }

    public void DisableAttack()
    {
        //Disable GameObject
        enemyattackBox.SetActive(false);
    }

    public void soundAttack()
    {
        enemyAttack.Play();
    }



}
