using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This script was created by me
///  I learnt how to create this script by watching
///  university material (Animating swordsman) 
///  To have a understanding of animation events
///  https://www.youtube.com/watch?v=-IuvXTnQS4U&ab_channel=AwesomeTuts
/// </summary>
public class PlayerEvent : MonoBehaviour
{
    public GameObject playerattackBox;
    public AudioSource footstepone;
    public AudioSource footsteptwo;
    public AudioSource punch;

    //During Animations Turn on the GameObject

    public void Attack()
    {
        //Activate gameObject HitBox
        //Debug.Log("On");
        playerattackBox.SetActive(true);
        punch.Play();
    }

    public void EndAttack()
    {
        //Disable gameObject HitBox
        //Debug.Log("Off");
        playerattackBox.SetActive(false);
    }

    public void Footstepone()
    {
        footstepone.Play();
    }

    public void Footsteptwo()
    {
        footsteptwo.Play();
    }

}
