using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IProjectile : MonoBehaviour
{
	public float Speed;
	public float Damage;
	public float Range;

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
		if((transform.position - _distance).magnitude >= Range)
			Destroy(gameObject);
	}
}
