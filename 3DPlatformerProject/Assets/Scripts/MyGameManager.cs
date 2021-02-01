using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MyGameManager : MonoBehaviour
{
    public TMP_Text coinstxt;           // Text field for the coins text
    public TMP_Text livestxt;          // Text field for the lives text
    public TMP_Text boxestxt;          // Text field for the boxes text
    public bool gameover = false;

    public int coins = 0;    // Total number of coins around the map
    public int boxes = 0; //Total number of breakable boxes around the map
    public int coinscollected = 0;   // Player's coins collected
    public int boxesBroken = 0;
    public int lives = 5;       // the players ammount of lives
    public GameObject player;  // the player GameObject
    public PlayerController playerk;

    public Vector3 checkpointPos;

    public Vector3 startCheckpoint;

    public PlayerCheckpointPos checkpoint;

    // GameManager instance
    private static MyGameManager instance;
    public static MyGameManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

    }


    // Start is called before the first frame update
    void Start()
    {
        livestxt = GameObject.Find("LivesTxt").GetComponent<TMP_Text>();
        coinstxt = GameObject.Find("CoinsTxt").GetComponent<TMP_Text>();
        boxestxt = GameObject.Find("BoxesTxt").GetComponent<TMP_Text>();
        lives = 5;

        checkpoint = FindObjectOfType<PlayerCheckpointPos>();
        playerk = FindObjectOfType<PlayerController>();
        coins = GameObject.FindObjectsOfType<CoinsTrigger>().Length;
        boxes = GameObject.FindObjectsOfType<BoxCount>().Length;
        numOfLives(lives); // Display Lives
        numOfCoins(coins); // Display coins
        numOfBoxes(boxes);
    }


    // Update is called once per frame
    void Update()
    {
        numOfCoins(coins);
        numOfLives(lives);
        numOfBoxes(boxes);

        //Debug.Log(checkpointPos);

        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("TestScene"); //Test GameManager Loading everything fine
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            checkpointPos = startCheckpoint;
            SceneManager.LoadScene("TestScene"); //Test GameManager Loading everything fine
        }
        /*if (Input.GetKeyDown(KeyCode.K))
            LoseLife();*/ //Test
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


    public void numOfBoxes(int boxes)
    {
        boxestxt.text = boxesBroken + " / " + boxes;
    }

    public void boxBroken()
    {
        boxesBroken++;
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
    public void EnemyAttack(Vector3 direction)
    {
        lives = lives - 1;
        playerk.Knockback(direction);
        //Update the text file
        numOfLives(lives);

        if (lives <= 0)
        {
            setGameOver();
        }
    }

    //Take away a Life if called
    public void LoseLife()
    {
        lives = lives - 1;
        //Update the text file
        numOfLives(lives);

        checkpoint.PlayerPosition();
        //if the player has no more lifes set to GameOver
        if (lives <= 0)
        {
            setGameOver();
        }
    }

  
}
