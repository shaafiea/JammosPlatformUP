using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesTrigger : MonoBehaviour
{
    private MyGameManager gameManager;

    //Same as coin script but this time adds on to the lives
    void OnTriggerEnter(Collider col)
    {
        //Player Life Trigger using tag
        if (col.tag != "Player")
        {
            return;
        }
        gameManager.extralife();
        Object.Destroy(gameObject);
    }
}
