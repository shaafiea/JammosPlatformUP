using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    public GameObject playerattackBox;

    //During Animations Turn on the GameObject

    public void Attack()
    {
        //Activate gameObject HitBox
        //Debug.Log("On");
        playerattackBox.SetActive(true);
    }

    public void EndAttack()
    {
        //Disable gameObject HitBox
        //Debug.Log("Off");
        playerattackBox.SetActive(false);
    }
}
