using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This was created by me using University Material
/// 
/// The shatter and destruction where the Instantiate is done to destroy the box was taken from
/// https://www.youtube.com/watch?v=EgNV0PWVaS8&ab_channel=Brackeys
/// </summary>
public class HeadboxCollision : MonoBehaviour
{
    [SerializeField] private MyGameManager gameManager;
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
            other.GetComponent<CoinBoxHealth>().coinBoxHealth--;
            gameManager.Coingrab();
            Instantiate(coinEffect, transform.position, transform.rotation); 
            
            if (other.GetComponent<CoinBoxHealth>().coinBoxHealth <= 0)
            {
                gameManager.BoxBroken(); //Add to box score;
                Instantiate(pickupEffect, transform.position, transform.rotation); // Play Effect on pickup
                Destroy(other.gameObject);
            }
        }

    }
}
