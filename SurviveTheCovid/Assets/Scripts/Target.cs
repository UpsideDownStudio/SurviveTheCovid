using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class Target : MonoBehaviour
{
	[FormerlySerializedAs("Health")] public float health = 50f;

	public void TakeDamage(float damage)
	{
		health -= damage;

		if (health <= 0f)
		{
			Die();
		}
	}

	private void Die()
	{
		Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		//if (other.CompareTag("Projectile"))
		//{
		//	IProjectile projectile;
		//	if (other.TryGetComponent(out projectile))
		//	{
		//		TakeDamage(projectile.Damage);
		//		Destroy(projectile.gameObject);
		//	}
		//}
	}
}
