using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script was made by me using university material and Unity Documentation
/// https://canvas.kingston.ac.uk/courses/16390/pages/topic-page-unity
/// https://docs.unity3d.com/Manual/index.html
/// </summary>
public class PlayerHurt : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Call gameManager to activate KnockBack which will tell the player controller
            Vector3 hitDirection = other.transform.position - transform.position; //this will get the position of the player and push them
            hitDirection = hitDirection.normalized; // back in the direction they were hit from
            FindObjectOfType<MyGameManager>().EnemyAttack(hitDirection);
        }
    }
}
