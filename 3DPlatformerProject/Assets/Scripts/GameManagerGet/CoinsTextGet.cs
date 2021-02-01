using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsTextGet : MonoBehaviour
{
    private MyGameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
        gameManager.coinstxt = this.gameObject.GetComponent<TMP_Text>();
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
