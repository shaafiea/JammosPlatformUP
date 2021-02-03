using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This is a simple script for the game manager to find the UI Text Script
/// https://docs.unity3d.com/Manual/index.html
/// </summary>
public class RestartTextGet : MonoBehaviour
{
    private MyGameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
        gameManager.restarttxt = this.gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
