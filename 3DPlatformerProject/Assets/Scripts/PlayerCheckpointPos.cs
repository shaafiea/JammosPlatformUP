using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script was made by me using university material and Unity Documentation
/// https://canvas.kingston.ac.uk/courses/16390/pages/topic-page-unity
/// https://docs.unity3d.com/Manual/index.html
/// </summary>
public class PlayerCheckpointPos : MonoBehaviour
{
    [SerializeField] private MyGameManager gameManager;
    [SerializeField] private GameObject player;
    public CharacterController playercc;


    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
        gameManager.checkpoint = this.gameObject.GetComponent<PlayerCheckpointPos>();
    }
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = gameManager.checkpointPos;
        playercc = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayerPosition()
    {
        player.transform.position = gameManager.checkpointPos;
        //Debug.Log(transform.position);
    }

}
