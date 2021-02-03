using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script was heavily edited by me which was made by watching a tutorial series. 
/// Many changes were made and not everything was used.
/// https://www.youtube.com/watch?v=h2d9Wc3Hhi0&list=PLiyfvmtjWC_V_H-VMGGAZi7n5E0gyhc37
/// Any additional code not from the tutorial was created by me using Unity Documentation and University Material to help. 
/// https://canvas.kingston.ac.uk/courses/16390/pages/topic-page-unity
/// https://docs.unity3d.com/Manual/index.html
/// </summary>
public class PlayerController : MonoBehaviour
{

    //public GameObject playerModel;
    [SerializeField] private Animator animator;

    private MyGameManager gameManager;
    public AudioSource jump;
 

    //Values
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float walkSpeed = 5.0f;
    [SerializeField] private float jumpHeight = 7.5f;
    [SerializeField] private float boxjumpAdd = 4.5f;
    [SerializeField] private float gravityValue = 1.7f;
    [SerializeField] private float doubleJumpMultiplier = 1.2f;
    private float superJumpMultiplier = 1.7f;
    [SerializeField]private bool canDoubleJump = false;

    private CharacterController controller;
    private Vector3 move;
    public Vector3 playerVelocity;
    //public bool groundedPlayer;
    public float distToGround = 1.0f;

    public GameObject playerBreak; // PlayerFootCollisionTrigger

    public float knockbackForce;
    public float knockbackTime;
    [SerializeField]private float knockbackCounter;




    //Debug UI
    //public Text grounded_DebugText;
    //public Text doubleJumpText;
    //public Text isRunningText;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
        gameManager.playerk = this.gameObject.GetComponent<PlayerController>();
        gameManager.player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        //Get Animator and character controller onStart
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        transform.localScale = new Vector3(1, 1, 1);
        //groundedPlayer = controller.isGrounded; //Old Way of checking if the player is grounded 
        GroundCheck(); //Check if the player is grounded

        //Debug.Log(playerVelocity);
        if (knockbackCounter <= 0)
        {
            playerVelocity.x = 0;
            playerVelocity.z = 0;
            move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); //Get Inputs from Horizontal and Vertical
            move = move.normalized * playerSpeed; //Normalize the speed of the player so that pressing 2 buttons doesnt double the speed.
            controller.Move(move * Time.deltaTime);
            //Debug.Log(playerSpeed);

            //If the player is moving rotate the player's gameObject around
            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            //Jumping Mechanic

            if (isGrounded)
            {
                //playerBreak.gameObject.SetActive(false);
                canDoubleJump = true; // If player is grounded re-enable the doublejump
                                      //Debug.Log("IsTrue");

                // Changes the height position of the player..
                if (Input.GetButtonDown("Jump"))
                {
                    //Debug.Log("First Jump");
                    jump.Play();
                    playerVelocity.y = jumpHeight; //Let the player go up in the y axis
                }
            }
            else
            {
                //If the player double jump is still avaliable
                if (Input.GetButtonDown("Jump") && canDoubleJump)
                {
                    jump.Play();
                    //Debug.Log("Work");
                    canDoubleJump = false;
                    playerVelocity.y = jumpHeight * doubleJumpMultiplier; // Allow the player to go up again in the y axis
                }
            }
                //Run Mechanic

                //Increase the player's speed if they are holding
                if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
                {
                    playerSpeed = 7.5f;
                    animator.SetBool("IsRunning", true);
                    //isRunningText.text = "Run:On";
                }
                else if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    //Slow the player back down to their walk speed if they release the button
                    playerSpeed = walkSpeed;
                    animator.SetBool("IsRunning", false);
                    //isRunningText.text = "Run:Off";
                }        
        } else {
            knockbackCounter -= Time.deltaTime;
           // Debug.Log(knockbackCounter);
        }

        //Activate Attacking animation if the player is grounded and has press the left mouse button
        if (Input.GetButtonDown("Fire1") && isGrounded)
        {
            animator.SetBool("IsAttacking", true);

        }
        else
        {
            //Do not activate if conditions above are not met
            animator.SetBool("IsAttacking", false);
        }

        if (playerVelocity.y < 0)
        {
            playerBreak.gameObject.SetActive(true); // Activate the gameobject if the player is falling from the sky
        }

        if (playerVelocity.y > 0)
        {
            playerBreak.gameObject.SetActive(false); // Deactive the gameobject if the player is back on a surface.
        }

        //Allow the player to be able to jump and fall off platforms 
        playerVelocity.y = playerVelocity.y + (Physics.gravity.y * Time.deltaTime * gravityValue);
        controller.Move(playerVelocity * Time.deltaTime);

        animator.SetBool("IsGrounded", isGrounded); //Set Parameter
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")))); //Set parameter

    }

    // Grounded Boolean
    public bool isGrounded = false;


    //GroundCheck Function
    void GroundCheck()
    {
        //Check if the raycast from the player's GameObjects is hitting the floor
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f)) 
        { 
            //Set true if on the ground
            //grounded_DebugText.text = "Grounded";
            isGrounded = true;
        }
        else
        {
            //Set false if in the air
            //grounded_DebugText.text = "Not Grounded";
            isGrounded = false;
        }

    }

    //Jumping Effects
    public void boxBreak()
    {
        //forces the player back in the air by the mutiplier given
        playerVelocity.y = boxjumpAdd;
        jump.Play();
    }

    public void superBoxJump()
    {
        //Increase the jump height by a big ammount sends the player very high
        playerVelocity.y = jumpHeight * superJumpMultiplier;
        jump.Play();
    }


    //Knockback

    public void Knockback(Vector3 direction)
    {
        knockbackCounter = knockbackTime;
        playerVelocity = direction * knockbackForce;
        playerVelocity.y = knockbackForce;
    }

}
