using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This code was created by me
/// This code will simply take away health from the coin box
/// </summary>
public class CoinBoxHealth : MonoBehaviour
{
    public int coinBoxHealth = 5; //Health of coinbox
    public GameObject destroyedCoinbox; // destroyed coinbox
    [SerializeField] private PlayerController playercontroller; //Gain Access to scripts playercontroller, enemyAI and GameManager
    [SerializeField] private MyGameManager gameManager;
    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void takeHealth()
    {
        coinBoxHealth--; //Minus the variable by 1
    }
}
