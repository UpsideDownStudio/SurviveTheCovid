using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : ItemPickup
{
	[FormerlySerializedAs("WeaponStats")] public WeaponStats weaponStats;
	protected float NextTimeToFire = 0f;

	public override void Interact()
	{
		base.Interact();
		WeaponManager.Instance.AddWeapon(gameObject.GetComponent<Weapon>());
	}

	public virtual void Shoot(RaycastHit hit)
	{
		if (Input.GetButtonDown("Fire1") && Time.time >= NextTimeToFire)
		{
			NextTimeToFire = Time.time + 1f / weaponStats.FireRate;
			SpawnProjectile(hit);
		}
	}
	public void SpawnProjectile(RaycastHit hit)
	{
		GameObject proj = Instantiate(weaponStats.Projectile.gameObject, transform.position, Quaternion.identity);
		proj.transform.forward = hit.point - transform.position;
		proj.GetComponent<Rigidbody>().AddForce(proj.transform.forward * weaponStats.Projectile.speed);
	}
}
