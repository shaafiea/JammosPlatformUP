using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scirpt was to test the box breaking collider but is not used in the script anymore
/// The Line 21 was taught by Brackeys video on how instantiate a prefab which 
/// uses the western props
/// https://www.youtube.com/watch?v=EgNV0PWVaS8&t=37s&ab_channel=Brackeys
/// </summary>
public class BoxBreak : MonoBehaviour
{

    //OLD SCRIPT WAY OF DESTROYING BOX

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
