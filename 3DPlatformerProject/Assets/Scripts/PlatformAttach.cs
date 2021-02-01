using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    [SerializeField] private GameObject player;

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform; //Keep Player On Platform
        }

    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject == player)
        {
            player.transform.parent = null; //Keep Player On Platform
        }
    }



}
