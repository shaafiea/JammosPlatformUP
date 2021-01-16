using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playercontroller;
    [SerializeField] private EnemyAI enemyAI;
    public GameObject destroyedbox; // destroyed
    public GameObject coin;

    private GameObject clone; // Cloned Box Of DestroyedBox
    private GameObject coinClone; // cloned ver of a coin
    
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
                playercontroller.boxBreak();
                clone = (GameObject)Instantiate(destroyedbox, transform.position, transform.rotation);
                //coinClone = (GameObject)Instantiate(coin, transform.position, transform.rotation);
                //Remove destroyed brief after 2 seconds
                Destroy(clone, 2f);
                //Destroy Full Crate once stomped on
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Work");
            if (playercontroller.playerVelocity.y < 0)
            {
                enemyAI.EnemyLoseHealth();
                
            }

        }

        //Check for gameObjects that use the tag jumpBox
        if (other.gameObject.CompareTag("jumpBox"))
        {
            //If the player is falling after jumping and collides with the box
            //Bounce the player upwards really high
            if (playercontroller.playerVelocity.y < 0)
            {
                playercontroller.superBoxJump();
      
            }
        }

    }

    void Update()
    {
       
    }


}
