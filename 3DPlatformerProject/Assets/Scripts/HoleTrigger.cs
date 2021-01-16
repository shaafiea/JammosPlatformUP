using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        //If the player falls into a whole they lose a life
        if (col.tag != "Player")
        {
            return;
        }
        MyGameManager.Instance.PlayerFall();
        //No destroying game object this will cause the player to fall infinite if they fall through the same whole again.
    }
}
