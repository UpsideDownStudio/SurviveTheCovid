using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
	public WeaponStats weaponStats;
	protected float nextTimeToFire = 0f;

	public virtual void Shoot(RaycastHit hit)
	{
		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
		{
			// nextTimeToFire = Time.time + 1f / weaponStats.fireRate;
			SpawnProjectile(hit);
		}
	}
	public void SpawnProjectile(RaycastHit hit)
	{
		Debug.Log(name);
		GameObject proj = Instantiate(weaponStats.projectile.gameObject, transform.position, Quaternion.identity);
		proj.transform.forward = hit.point - transform.position;
		proj.GetComponent<Rigidbody>().AddForce(proj.transform.forward * weaponStats.speedProjectile);
	}
}
