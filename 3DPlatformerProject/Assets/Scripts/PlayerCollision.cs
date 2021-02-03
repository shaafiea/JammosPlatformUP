using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This was created by me using University Material
/// The shatter and destruction where the Instantiate is done to destroy the box was taken from
/// https://www.youtube.com/watch?v=EgNV0PWVaS8&ab_channel=Brackeys
/// </summary>
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playercontroller; //Gain Access to scripts playercontroller, enemyAI and GameManager
    [SerializeField] private EnemyAI enemyAI;
    [SerializeField] private MyGameManager gameManager;

    public GameObject destroyedbox; // destroyed normal box
    public GameObject coin; //Coin (test)

    private GameObject clone; // Cloned Box Of DestroyedBox
                              //private GameObject coinClone; // cloned ver of a coin

    private CoinBoxHealth healthbox;
    public GameObject destroyedCoinbox; // destroyed coinbox
    [SerializeField] private GameObject pickupEffect; //Particle system for coin

    //Lifebox broken and Effect
    public GameObject destroyedLifebox;
    [SerializeField] private GameObject lifeupEffect;



    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check for gameObjects that use the tag Boxes
        if (other.gameObject.CompareTag("Boxes"))
        {
            //Debug.Log("Player Touching Box");

            //If the player is falling after jumping and collides with the box
            //Break the box
            if (playercontroller.playerVelocity.y < 0)
            {
                gameManager.BoxBroken(); //Add to box score;
                playercontroller.boxBreak();
                clone = (GameObject)Instantiate(destroyedbox, transform.position, transform.rotation);
                //coinClone = (GameObject)Instantiate(coin, transform.position, transform.rotation); //This was a test to see if a coin would spawn on break
                //Remove destroyed brief after 2 seconds
                Destroy(clone, 2f);
                //Destroy Full Crate once stomped on
                Destroy(other.gameObject);
            }
        }


        //Enemy Attack
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Work");
            if (playercontroller.playerVelocity.y < 0)
            {
                //If the player jumps on the enemies's heads take away their life
                enemyAI = other.gameObject.GetComponent<EnemyAI>();
                enemyAI.EnemyLoseHealth();

                //Cause the player to jump back up from the collision
                playercontroller.boxBreak();

            }

        }

        //Check for gameObjects that use the tag jumpBox
        if (other.gameObject.CompareTag("jumpBox"))
        {
            //If the player is falling after jumping and collides with the box
            //Bounce the player upwards really high
            if (playercontroller.playerVelocity.y < 0)
            {
                playercontroller.superBoxJump(); //Cause the player to jump up really high

            }
        }

        //Check for gameObject with tag CoinBoxFloor
        if (other.gameObject.CompareTag("CoinBoxFloor"))
        {
            if (playercontroller.playerVelocity.y < 0)
            {

                //If the player is falling from the air and lands on a CoinBox 
                playercontroller.boxBreak(); // Lift the player back in the air
                //coinBoxHealth = coinBoxHealth - 1;
                other.GetComponent<CoinBoxHealth>().coinBoxHealth--;// Minus one health from the coin box
                gameManager.Coingrab(); // Add one coin to the coins earned
                Instantiate(pickupEffect, transform.position, transform.rotation); // Play Particle Effect on pickup


                //If the health of the coinBox is less than or equal to 0
                if (other.GetComponent<CoinBoxHealth>().coinBoxHealth <= 0)
                {
                    gameManager.BoxBroken(); //Add to box score;
                    playercontroller.boxBreak(); // Lift the player back in the air
                    clone = (GameObject)Instantiate(destroyedCoinbox, transform.position, transform.rotation); // Clone in the broken box
                    Destroy(clone, 2f); // Destroy the broken box after 2 seconds
                    Destroy(other.gameObject); // Destroy the original coinbox
                }
            }


        }

        //Check for gameObject with tag CoinBoxFloor
        if (other.gameObject.CompareTag("CoinBoxFloorJump"))
        {
            if (playercontroller.playerVelocity.y < 0)
            {

                //If the player is falling from the air and lands on a CoinBox 
                playercontroller.superBoxJump(); // Lift the player back in the air high                   
                other.GetComponent<CoinBoxHealth>().coinBoxHealth--;// Minus one health from the coin box
                gameManager.Coingrab(); // Add one coin to the coins earned
                Instantiate(pickupEffect, transform.position, transform.rotation); // Play Particle Effect on pickup


                //If the health of the coinBox is less than or equal to 0
                if (other.GetComponent<CoinBoxHealth>().coinBoxHealth <= 0)
                {
                    gameManager.BoxBroken(); //Add to box score;
                    playercontroller.superBoxJump(); // Lift the player back in the air
                    clone = (GameObject)Instantiate(destroyedCoinbox, transform.position, transform.rotation); // Clone in the broken box
                    Destroy(clone, 2f); // Destroy the broken box after 2 seconds
                    Destroy(other.gameObject); // Destroy the original coinbox
                }
            }
        }



        //Check for gameObject with tag Lifebox
        if (other.gameObject.CompareTag("Lifebox"))
        {
            //If the player is falling from the air
            if (playercontroller.playerVelocity.y < 0)
            {
                gameManager.BoxBroken(); //Add to box score;
                gameManager.Extralife(); //If he lands on the lifebox add an extra life to his lives

                Instantiate(lifeupEffect, transform.position, transform.rotation); // Play Effect on pickup
                playercontroller.boxBreak(); // Lift the player into the air
                clone = (GameObject)Instantiate(destroyedLifebox, transform.position, transform.rotation); //Clone in the broken Lifebox
                Destroy(clone, 2f); //Destroy the clone broken box after 2 seconds
                //Destroy Full Crate once stomped on
                Destroy(other.gameObject);
            }
        }


        //Check for gameObject with tag Lifeboxair
        if (other.gameObject.CompareTag("LifeboxAir"))
        {
            //If the player is falling from the air
            if (playercontroller.playerVelocity.y < 0)
            {
                gameManager.BoxBroken(); //Add to box score;
                gameManager.Extralife(); //If he lands on the lifebox add an extra life to his lives

                Instantiate(lifeupEffect, transform.position, transform.rotation); // Play Effect on pickup
                playercontroller.superBoxJump(); // Lift the player into the air super high
                clone = (GameObject)Instantiate(destroyedLifebox, transform.position, transform.rotation); //Clone in the broken Lifebox
                Destroy(clone, 2f); //Destroy the clone broken box after 2 seconds
                                    //Destroy Full Crate once stomped on
                Destroy(other.gameObject);
            }
        }


    }
    void Update()
    {
       
    }


}
