using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    private MyGameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
    }

    //Complete Level if player enters the endLevelTrigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        gameManager.levelcompleted();
    }
}
