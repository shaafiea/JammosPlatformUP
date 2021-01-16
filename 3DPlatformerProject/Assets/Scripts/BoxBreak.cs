using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreak : MonoBehaviour
{

    public GameObject player;
    public GameObject destroyedbox;
    public Collider topOfBox;

    void OnTriggerEnter(Collider topOfBox)
    {
        this.GetComponent<Collider>().enabled = false;
        Instantiate(destroyedbox, transform.position, transform.rotation);
        Destroy(gameObject, 5f);

        
    }
}
