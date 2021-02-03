using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script was taken from university material
/// https://canvas.kingston.ac.uk/courses/16390/pages/topic-page-unity
/// </summary>
public class DrawWaypoint : MonoBehaviour
{
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, 1);
	}

}
