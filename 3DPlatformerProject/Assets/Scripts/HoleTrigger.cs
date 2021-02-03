using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This code was created by me using Unity's OnTrigger Enter Function to call a specific function
///  within the game manager
/// </summary>
public class HoleTrigger : MonoBehaviour
{
    private MyGameManager gameManager;
    public GameObject player;
    public CharacterController playercc;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
        playercc = player.GetComponent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        //If the player falls into a whole they lose a life
        if (other.gameObject.tag == "Player")
        {
            playercc.enabled = false;
            gameManager.LoseLife();
            playercc.enabled = true;
        }
            
        //No destroying game object this will cause the player to fall infinite if they fall through the same whole again.
    }
}
