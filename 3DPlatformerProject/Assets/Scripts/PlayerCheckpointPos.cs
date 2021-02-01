using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheckpointPos : MonoBehaviour
{
    [SerializeField] private MyGameManager gameManager;
    [SerializeField] private GameObject player;


    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
        gameManager.checkpoint = this.gameObject.GetComponent<PlayerCheckpointPos>();
    }
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = gameManager.checkpointPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }


    public void PlayerPosition()
    {
        player.transform.position = gameManager.checkpointPos;
        //Debug.Log(transform.position);
    }

}
