using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    public Transform startCheckpoint;
    public Transform checkpoint;
    [SerializeField] private MyGameManager gameManager;
    [SerializeField] private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.checkpointPos = player.transform.position;
        }
    }
}
