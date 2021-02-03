using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script was created by me after searching through the unity documentations and University Materials
/// https://docs.unity3d.com/Manual/index.html
/// https://canvas.kingston.ac.uk/courses/16390/pages/topic-page-unity
/// Smooth Factor was taken from the youtube video
/// https://www.youtube.com/watch?v=IeuqDVKfJag&list=PLiyfvmtjWC_V_H-VMGGAZi7n5E0gyhc37&index=4&ab_channel=gamesplusjamesS
/// </summary>
public class CameraFollow : MonoBehaviour
{
	public Transform player;
	[SerializeField] Vector3 offset;
	[Range(0.01f, 1.0f)]
	public float SmoothFactor = 0.5f;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//This get the camera to follow the player from the player's position and the camera's transform.position
		Vector3 newPos = player.position + offset;
		transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
	}
}
