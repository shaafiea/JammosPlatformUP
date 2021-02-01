using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Fall", true);
            animator.SetBool("Rise", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Fall", false);
        animator.SetBool("Rise", true);

    }


    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Fall", false);
        animator.SetBool("Rise", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
