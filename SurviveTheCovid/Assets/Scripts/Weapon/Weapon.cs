using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ItemPickup
{
	public WeaponStats WeaponStats;
	protected float _nextTimeToFire = 0f;

	public override void Interact()
	{
		base.Interact();

		WeaponManager.instance.AddWeapon(gameObject.GetComponent<Weapon>());
	}

	public virtual void Shoot(RaycastHit hit)
	{
		if (Input.GetButtonDown("Fire1") && Time.time >= _nextTimeToFire)
		{
			_nextTimeToFire = Time.time + 1f / WeaponStats.FireRate;
			SpawnProjectile(hit);
		}
	}
	public void SpawnProjectile(RaycastHit hit)
	{
		GameObject proj = Instantiate(WeaponStats.Projectile.gameObject, transform.position, Quaternion.identity);
		proj.transform.forward = hit.point - transform.position;
		proj.GetComponent<Rigidbody>().AddForce(proj.transform.forward * WeaponStats.Projectile.Speed);
	}
}
