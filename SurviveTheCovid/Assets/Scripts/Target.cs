using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Assets.Scripts.Weapon;
using UnityEngine;
using UnityEngine.Serialization;

public class Target : MonoBehaviour
{
	public float health = 50f;

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
}
