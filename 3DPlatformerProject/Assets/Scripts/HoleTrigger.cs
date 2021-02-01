using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    private MyGameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        //If the player falls into a whole they lose a life
        if (other.gameObject.tag == "Player")
            gameManager.LoseLife();
        //No destroying game object this will cause the player to fall infinite if they fall through the same whole again.
    }
}
