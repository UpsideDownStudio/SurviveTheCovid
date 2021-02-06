using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float Smooth = 5.0f;
    public Vector3 offset = new Vector3(0,13,-19);

    void Update()
    {
	    transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * Smooth);
    }
}
