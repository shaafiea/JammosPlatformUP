using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a simple script for the game manager to the player's character controller
/// https://docs.unity3d.com/Manual/index.html
/// </summary>
public class CharacterControllerGet : MonoBehaviour
{
    private MyGameManager gameManager;
    public GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
        gameManager.playercc = Player.gameObject.GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
