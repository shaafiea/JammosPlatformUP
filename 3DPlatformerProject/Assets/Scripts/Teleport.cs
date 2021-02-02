using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject destination;
    public GameObject player;
    public CharacterController playercc;
    // Start is called before the first frame update
    void Start()
    {
        playercc = player.GetComponent<CharacterController>();
    }

    //If the player enters the trigger then teleport them to the new destination
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playercc.enabled = false; 
            player.transform.position = destination.transform.position;
            Debug.Log("Work");
            Debug.Log(other.gameObject.name);
            Debug.Log(player.transform.position);
            Debug.Log(destination.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playercc.enabled = true;
    }
}
