using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Smooth = 5.0f;
	public Vector3 Offset;

	private void Start()
	{
		Offset = transform.position;
	}

	void Update()
    {
	    transform.position = Vector3.Lerp(transform.position, Target.position + Offset, Time.deltaTime * Smooth);
    }
}
