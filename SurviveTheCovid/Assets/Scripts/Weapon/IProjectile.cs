using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IProjectile : MonoBehaviour
{
	public float Speed;
	public float Damage;
	public float Range;
	public float DamageRadius;

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

	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, DamageRadius);
	}

	//TODO: Реализовать урон по области.
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			Target target;
			if (other.TryGetComponent(out target))
			{
				target.TakeDamage(Damage);
				Destroy(gameObject);
			}
		}
	}
}
