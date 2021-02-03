using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// This script was made by me using university material and Unity Documentation
/// https://canvas.kingston.ac.uk/courses/16390/pages/topic-page-unity
/// https://docs.unity3d.com/Manual/index.html
/// 
/// Some parts of the script reference to things in other code that make use of code from videos
/// https://www.youtube.com/watch?v=h2d9Wc3Hhi0&list=PLiyfvmtjWC_V_H-VMGGAZi7n5E0gyhc37
/// https://www.youtube.com/watch?v=ofCLJsSUom0&t=305s&ab_channel=Blackthornprod
/// </summary>
public class MyGameManager : MonoBehaviour
{
    public TMP_Text coinstxt;           // Text field for the coins text
    public TMP_Text livestxt;          // Text field for the lives text
    public TMP_Text boxestxt;          // Text field for the boxes text
    public TMP_Text wingametxt;
    public TMP_Text gameovertxt;
    public TMP_Text restarttxt;
    public TMP_Text boxesDestroyedtxt;

    public bool wingame = false;
    public bool losegame = false;
    public bool gameover = false;


    public AudioSource levelmusic;
    public AudioSource coinsound;
    public AudioSource lifeup;
    public AudioSource loselife;
    public AudioSource gameEnded;

    public int coins = 0;    // Total number of coins around the map
    public int boxes = 0; //Total number of breakable boxes around the map
    public int endlevelboxes = 0;
    public int coinscollected = 0;   // Player's coins collected
    public int boxesBroken = 0;
    public int lives = 5;       // the players ammount of lives
    public GameObject player;  // the player GameObject
    public PlayerController playerk;
    public CharacterController playercc;

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
        playercc = player.GetComponent<CharacterController>();
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
        playercc.enabled = true;
    /*    livestxt = GameObject.Find("LivesTxt").GetComponent<TMP_Text>();
        coinstxt = GameObject.Find("CoinsTxt").GetComponent<TMP_Text>();
        boxestxt = GameObject.Find("BoxesTxt").GetComponent<TMP_Text>();
        gameovertxt = GameObject.Find("GameoverTxt").GetComponent<TMP_Text>();
        wingametxt = GameObject.Find("WinTxt").GetComponent<TMP_Text>();
        boxesDestroyedtxt = GameObject.Find("BoxesCountTxt").GetComponent<TMP_Text>();*/
        lives = 5;
        checkpoint = FindObjectOfType<PlayerCheckpointPos>();
        playerk = FindObjectOfType<PlayerController>();
        coins = GameObject.FindObjectsOfType<CoinsTrigger>().Length;
        boxes = GameObject.FindObjectsOfType<BoxCount>().Length;
        endlevelboxes = GameObject.FindObjectsOfType<BoxCount>().Length;
        NumOfLives(lives); // Display Lives
        NumOfCoins(); // Display coins
        NumOfBoxes(boxes); // Display boxcount
        WinBoxCount(endlevelboxes);
        GameOverText();
        gameover = false;
        wingame = false;
        losegame = false;
        
    }


    // Update is called once per frame
    void Update()
    {
        NumOfCoins();
        NumOfLives(lives);
        NumOfBoxes(boxes);
        WinBoxCount(endlevelboxes);
        GameOverText();
        //Debug.Log(checkpointPos);

        if (Input.GetKeyDown(KeyCode.R))
        {
            coinscollected = 0;
            boxesBroken = 0;
            losegame = false;
            wingame = false;
            playercc.enabled = false;
            checkpointPos = startCheckpoint;
            gameover = false;
            SceneManager.LoadScene("LevelScene"); //Test GameManager Loading everything fine
            playercc.enabled = true;
            levelmusic.Play();
        }
        /*if (Input.GetKeyDown(KeyCode.K))
            LoseLife();*/ //Test

        if (gameover == false)
        {
            Time.timeScale = 1f;
        }
    }

    public void Coingrab()
    {
        // Check that not game over
        if (gameover) return;

        // Player finds coin
        coinscollected++;

        //Play sound effect
        coinsound.Play();

        //Update the text file
        NumOfCoins();

        //Player Gains Extra Life if they collected a number of Coins
        if (coinscollected == 50)
        {
            coinscollected = 0;
            lives = lives + 1;
            lifeup.Play();
        }

    }

    //showcase numberOfLives
    public void NumOfLives(int lives)
    {
       livestxt.text = " " + lives;
    }

    public void NumOfCoins()
    {
        coinstxt.text = "" + coinscollected;
    }


    public void NumOfBoxes(int boxes)
    {
        boxestxt.text = boxesBroken + " / " + boxes;
    }

    public void GameOverText()
    {
        if (gameover == false)
        {
            wingametxt.text = "";
            gameovertxt.text = "";
        }    

        if (wingame == true && losegame == false)
        {
            wingametxt.text = "You Win";
            gameovertxt.text = "";
           
        } else if (losegame == true && wingame == false)
        {
            wingametxt.text = "";
            gameovertxt.text = "Game Over";
        }
    }    
    public void WinBoxCount(int endlevelboxes)
    {
        if (gameover == false)
        {
            boxesDestroyedtxt.text = "";

        }

        if (gameover == true && wingame == true)
        {
            restarttxt.text = "";
            boxesDestroyedtxt.text = "You have broken " + boxesBroken + " / " + endlevelboxes;
        }

        if (gameover == true && losegame == true)
        {
            boxesDestroyedtxt.text = "";
            restarttxt.text = "Press r to restart";
        }
    }

    public void BoxBroken()
    {
        //Add 1 to the UIText for boxes broken
        boxesBroken++;
    }

    public void Extralife()
    {
        // Check that not game over
        if (gameover) return;

        // Add On to the lives
        lives++;
        lifeup.Play();

        //Update numOflives
        NumOfLives(lives);
    }

    public bool IsGameOver()
    {
        return gameover;
    }

    //If player beats the game
    public void Levelcompleted()
    {
        SetWinGame();
    }

    // load winning scene if player wins
    public void SetWinGame()
    {
        gameEnded.Play();
        gameover = true;
        if (gameover == true)
        {
            wingame = true;
            losegame = false;
            Time.timeScale = 0f;
        }
    }

    // load gameover scene if player loses
    public void SetGameOver()
    {
        gameEnded.Play();
        gameover = true;
        boxesDestroyedtxt.gameObject.SetActive(false);
        if (gameover == true)
        {
            losegame = true;
            wingame = false;
            checkpointPos = startCheckpoint;
            Time.timeScale = 0f;
        }
    }

    // Something has attacked the player
    public void EnemyAttack(Vector3 direction)
    {
        lives = lives - 1;
        loselife.Play();
        playerk.Knockback(direction);
        //Update the text file
        NumOfLives(lives);

        if (lives <= 0)
        {
            SetGameOver();
        }
    }

    //Take away a Life if called
    public void LoseLife()
    {
        lives = lives - 1;
        loselife.Play();
        //Update the text file
        NumOfLives(lives);

        checkpoint.PlayerPosition();
        
        //if the player has no more lifes set to GameOver
        if (lives <= 0)
        {
            SetGameOver();
        }
    }

  
}
