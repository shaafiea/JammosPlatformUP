using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script was made by me using university material and Unity Documentation
/// https://canvas.kingston.ac.uk/courses/16390/pages/topic-page-unity
/// https://docs.unity3d.com/Manual/index.html
/// </summary>
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
        gameManager.Extralife();
        Object.Destroy(gameObject);
    }
}
