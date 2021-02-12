using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Target : MonoBehaviour
{
	public float Health = 50f;

	public void TakeDamage(float damage)
	{
		Health -= damage;

		if (Health <= 0f)
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
