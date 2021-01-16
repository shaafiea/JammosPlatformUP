using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{

    //public GameObject playerModel;
    [SerializeField] private Animator animator;
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpHeight = 7.5f;
    [SerializeField] private float gravityValue = 1.7f;

    [SerializeField] private float doubleJumpMultiplier = 1.2f;
    private bool canDoubleJump = false;

    private CharacterController controller;
    private Vector3 move;
    private Vector3 playerVelocity;
    //public bool groundedPlayer;
    public float distToGround = 1.0f;
    public float rotateSpeed;
    public Transform pivot;

    //Debug UI
    public Text grounded_DebugText;
    public Text doubleJumpText;
    public Text isRunningText;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //groundedPlayer = controller.isGrounded;
        GroundCheck();


        float yStore = move.y;
        move = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        move = move.normalized * playerSpeed;
        move.y = yStore;

        /* move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
         move = move.normalized * playerSpeed;
         controller.Move(move * Time.deltaTime);
         //Debug.Log(playerSpeed);*/
        playerVelocity.y = playerVelocity.y + (Physics.gravity.y * gravityValue * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);

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
        }
        else
        {
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                playerVelocity.y = jumpHeight * doubleJumpMultiplier;
                canDoubleJump = false;
            }


        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            playerSpeed = 7.5f;
            animator.SetBool("IsRunning", true);
            isRunningText.text = "Run:On";
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            playerSpeed = 5.0f;
            animator.SetBool("IsRunning", false);
            isRunningText.text = "Run:Off";
        }

        //Move the player in camera's look direction
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(move.x, 0f, move.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

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
            grounded_DebugText.text = "Grounded";
            isGrounded = true;
        }
        else
        {
            grounded_DebugText.text = "Not Grounded";
            isGrounded = false;
        }

    }

}
