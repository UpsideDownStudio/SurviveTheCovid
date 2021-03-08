using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
	public float range;
	private Vector3 _distance;

	void Start()
	{
		_distance = transform.position;
	}

	void Update()
	{
		CheckDistance();
	}

	public void CheckDistance()
	{
		if((transform.position - _distance).magnitude >= range)
			Destroy(gameObject);
	}
}
