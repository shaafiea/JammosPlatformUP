using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsTrigger : MonoBehaviour
{
    [SerializeField] private MyGameManager myGameManager;

    private void Awake()
    {
        myGameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        //Player Coin Trigger using tag
        if (col.tag != "Player")
        {
            return;
        }
        else
        {
            myGameManager.coingrab();
            Object.Destroy(gameObject);
        }
    }

    private void Update()
    {
        //Rotate the coin
        transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
    }

}
