using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
	[FormerlySerializedAs("Speed")] public float speed;
	[FormerlySerializedAs("Damage")] public float damage;
	[FormerlySerializedAs("Range")] public float range;
	[FormerlySerializedAs("DamageRadius")] public float damageRadius;

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

	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, damageRadius);
	}

	//TODO: Реализовать урон по области.
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			Target target;
			if (other.TryGetComponent(out target))
			{
				target.TakeDamage(damage);
				Destroy(gameObject);
			}
		}
	}
}
