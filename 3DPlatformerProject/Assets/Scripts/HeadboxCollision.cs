using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadboxCollision : MonoBehaviour
{
    [SerializeField] private MyGameManager gameManager;
    [SerializeField] private int coinBoxHealth = 5;
    [SerializeField] private GameObject pickupEffect; //Particle system
    [SerializeField] private GameObject coinEffect;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>(); //Have access to gameManager
    }

    private void OnTriggerEnter(Collider other)
    {
        //When player hits the coinbox with his head give the player a coin
        //decrease health and destroy the box if health = 0
        if (other.gameObject.CompareTag("CoinBoxAbove"))
        {
            coinBoxHealth = coinBoxHealth - 1;
            gameManager.coingrab();
            Instantiate(coinEffect, transform.position, transform.rotation); 
            
            if (coinBoxHealth <= 0)
            {
                gameManager.boxBroken(); //Add to box score;
                Instantiate(pickupEffect, transform.position, transform.rotation); // Play Effect on pickup
                Destroy(other.gameObject);
            }
        }

    }
}
