using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWeapon : MonoBehaviour
{
	public WeaponStats WeaponStats;
	private float nextTimeToFire = 0f;

	public virtual void Shoot(RaycastHit hit)
	{
		if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
		{
			nextTimeToFire = Time.time + 1f / WeaponStats.FireRate;
			GameObject proj = Instantiate(WeaponStats.Projectile.gameObject, transform.position, Quaternion.identity);
			proj.transform.forward = hit.point - transform.position;
			proj.GetComponent<Rigidbody>().AddForce(proj.transform.forward * WeaponStats.Projectile.Speed);
		}
	}
}
