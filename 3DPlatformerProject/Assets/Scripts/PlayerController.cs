using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //public GameObject playerModel;
    [SerializeField] private Animator animator;
    [SerializeField] private float playerSpeed = 3.0f;
    [SerializeField] private float jumpHeight = 7.5f;
    [SerializeField] private float gravityValue = 1.7f;

    [SerializeField] private float doubleJumpMultiplier = 1.2f;
    private float superJumpMultiplier = 1.2f;
    private bool canDoubleJump = false;

    private CharacterController controller;
    private Vector3 move;
    public Vector3 playerVelocity;
    //public bool groundedPlayer;
    public float distToGround = 1.0f;

    public CapsuleCollider punchhitbox; // the hitbox for the punch


    //Debug UI
    /*public Text grounded_DebugText;
    public Text doubleJumpText;
    public Text isRunningText;*/

    // Player Controller instance
    private static PlayerController instance = null;
    public static PlayerController Instance
    {
        get
        {
            return instance;
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        punchhitbox.enabled = false;
    }

    void Update()
    {
        //groundedPlayer = controller.isGrounded;
        GroundCheck();

         move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
         move = move.normalized * playerSpeed;
         controller.Move(move * Time.deltaTime);
         //Debug.Log(playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (isGrounded)
       {
           canDoubleJump = true;

           // Changes the height position of the player..
           if (Input.GetButtonDown("Jump"))
            { 
                playerVelocity.y = jumpHeight;
            }
       } else
       {
           if (Input.GetButtonDown("Jump") && canDoubleJump)
           {
               playerVelocity.y = jumpHeight * doubleJumpMultiplier;
               canDoubleJump = false;
           }

          
       }


        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            playerSpeed = 5.5f;
            animator.SetBool("IsRunning", true);
           //isRunningText.text = "Run:On";
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            playerSpeed = 3.0f;
            animator.SetBool("IsRunning", false);
            //isRunningText.text = "Run:Off";
        }

        if (Input.GetButtonDown("Fire1") && isGrounded)
        {
            animator.SetBool("IsAttacking", true);
            
        } else
        {
            animator.SetBool("IsAttacking", false);
        }


        playerVelocity.y = playerVelocity.y + (Physics.gravity.y * gravityValue * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);

        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

    }

    private void FixedUpdate()
    {
      
    }

    public bool isGrounded = false;

    void GroundCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f)) 
        { 
            //grounded_DebugText.text = "Grounded";
            isGrounded = true;
        }
        else
        {
            //grounded_DebugText.text = "Not Grounded";
            isGrounded = false;
        }

    }

    public void boxBreak()
    {
        playerVelocity.y = jumpHeight;
    }

    public void superBoxJump()
    {
        playerVelocity.y = jumpHeight * superJumpMultiplier;
    }

    public void Attacked()
    {

    }

}
