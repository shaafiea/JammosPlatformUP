﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlatformAttact : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public bool onplatform = false;

    public Vector3 lastpos;



    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform; //Keep Player On Platform
            onplatform = true;
        }

    }

    private void Update()
    {
        if (onplatform)
        {
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.Move((transform.position - lastpos) * 0.5f);
        }

        lastpos = transform.position;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null; //Keep Player On Platform
            onplatform = false;
        }
    }
}
