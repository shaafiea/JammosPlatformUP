using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This script is heavily edited by me
/// This script was edited from this video
/// https://www.youtube.com/watch?v=ofCLJsSUom0&t=303s&ab_channel=Blackthornprod
/// </summary>
public class Checkpoint : MonoBehaviour
{
    public Color color;

    public Transform startCheckpoint;
    public Transform checkpoint;
    [SerializeField] private MyGameManager gameManager;
    [SerializeField] private GameObject player;
    public AudioSource checkpointaudio;
    public TMP_Text checkpointtxt;
    public bool playsound;
    public Color checkcolor;
   
    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<Renderer>().material.color;
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
        checkpointtxt.text = "";
        
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Material mat = GetComponent<Renderer>().material;
        GetComponent<Renderer>().sharedMaterial.color = checkcolor; //Change colour of material

        if (other.gameObject.tag == "Player")
        {
            checkpointaudio.Play(); //Play Audio
            checkpointtxt.text = "Checkpoint Reached"; //Set the text as this
            gameManager.checkpointPos = player.transform.position; //Set the checkpoint position as the player transform position

        }
    }

    private void OnTriggerExit(Collider other)
    {
        checkpointtxt.text = ""; //Set the text as this
    }
}
