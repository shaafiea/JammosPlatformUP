using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesTrigger : MonoBehaviour
{

    //Same as coin script but this time adds on to the lives
    void OnTriggerEnter(Collider col)
    {
        //Player Coin Trigger using tag
        if (col.tag != "Player")
        {
            return;
        }
        MyGameManager.Instance.extralife();
        Object.Destroy(gameObject);
    }
}
