using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MyGameManager : MonoBehaviour
{
    public TMP_Text coinstxt;           // Text field for the coins text
    public TMP_Text livestxt;          // Text field for the lives text
    public bool gameover = false;

    public int coins = 0;    // Total number of coins around the map
    public int coinscollected = 0;   // Player's coins collected
    public int lives = 5;       // the players ammount of lives
    GameObject player;  // the player GameObject

    // GameManager instance
    private static MyGameManager instance = null;
    public static MyGameManager Instance
    {
        get
        {
            return instance;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        numOfLives(lives); // Display Lives
        numOfCoins(coins); // Display coins

        coins = GameObject.FindObjectsOfType<CoinsTrigger>().Length;

    }

    // Init the game manager
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        numOfCoins(coins);
        numOfLives(lives);

        if (Input.GetKeyDown(KeyCode.K))
            EnemyAttack();
    }

    public void coingrab()
    {
        // Check that not game over
        if (gameover) return;

        // Player finds coin
        coinscollected++;

        //Update the text file
        numOfCoins(coins);

        //Player Gains Extra Life if they collected a number of Coins
        if (coinscollected == 100)
        {
            coinscollected = 0;
            lives = lives + 1;
        }

    }

    //showcase numberOfLives
    public void numOfLives(int lives)
    {
       livestxt.text = " " + lives;
    }

    public void numOfCoins(int coins)
    {
        coinstxt.text = "" + coinscollected;
    }

    public void extralife()
    {
        // Check that not game over
        if (gameover) return;

        // Add On to the lives
        lives++;

        //Update numOflives
        numOfLives(lives);
    }

    public bool isGameOver()
    {
        return gameover;
    }

    //If player beats the game
    public void levelcompleted()
    {
        setWinGame();
    }

    // load winning scene if player wins
    public void setWinGame()
    {
        gameover = true;
        SceneManager.LoadScene(sceneName: "WinGameScene");
    }
    // load gameover scene if player loses
    public void setGameOver()
    {
        gameover = true;
        SceneManager.LoadScene(sceneName: "GameOverScene");
    }

    // Something has attacked the player
    public void EnemyAttack()
    {
        lives = lives - 1;
        //Update the text file
        numOfLives(lives);

        if (lives <= 0)
        {
            setGameOver();
        }
    }

    public void PlayerFall()
    {
        lives = lives - 1;
        //Update the text file
        numOfLives(lives);

        if (lives <= 0)
        {
            setGameOver();
        }
    }

  
}
