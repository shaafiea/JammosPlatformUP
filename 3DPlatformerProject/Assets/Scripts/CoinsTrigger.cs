using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This code was created by me using Unity's OnTrigger Enter Function to call a specific function
///  within the game manager
///  
/// To make the coin rotate I have taken that code from Unity's Rollerball tutorial
///https://learn.unity.com/project/roll-a-ball
/// </summary>
public class CoinsTrigger : MonoBehaviour
{
    [SerializeField] private MyGameManager myGameManager;
    [SerializeField] private GameObject pickupEffect; //Particle system

    private void Awake()
    {
        myGameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        //Player Coin Trigger using tag
        if (col.tag != "Player")
        {
            return;
        }
        else
        {
            Instantiate(pickupEffect, transform.position, transform.rotation); // Play Effect on pickup
            myGameManager.Coingrab(); // Add to score
            Object.Destroy(gameObject); //Delete the coin picked up
        }
    }

    private void Update()
    {
        //Rotate the coin
        transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
    }

}
