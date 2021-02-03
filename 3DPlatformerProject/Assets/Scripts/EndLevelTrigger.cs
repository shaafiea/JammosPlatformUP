using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script was made by me using university material and Unity Documentation
/// https://canvas.kingston.ac.uk/courses/16390/pages/topic-page-unity
/// https://docs.unity3d.com/Manual/index.html
/// </summary>
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
        gameManager.Levelcompleted();
    }
}
