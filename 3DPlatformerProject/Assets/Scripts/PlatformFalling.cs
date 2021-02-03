using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script was made by me using university material and Unity Documentation
/// https://canvas.kingston.ac.uk/courses/16390/pages/topic-page-unity
/// https://docs.unity3d.com/Manual/index.html
/// </summary>
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
