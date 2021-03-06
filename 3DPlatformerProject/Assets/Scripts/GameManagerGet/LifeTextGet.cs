using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This is a simple script for the game manager to find the UI Text Script
/// https://docs.unity3d.com/Manual/index.html
/// </summary>
public class LifeTextGet : MonoBehaviour
{
    private MyGameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
        gameManager.livestxt = this.gameObject.GetComponent<TMP_Text>();
        gameManager.lives = 5;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
