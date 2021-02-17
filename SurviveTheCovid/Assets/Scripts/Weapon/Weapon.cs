using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : ItemPickup
{
	protected float nextTimeToFire = 0f;
	protected WeaponStats weaponStats;

	private void Start()
	{
		weaponStats = item as WeaponStats;
	}

	public override void Interact()
	{
		base.Interact();
		WeaponManager.Instance.AddWeapon(gameObject.GetComponent<Weapon>());
	}

	public virtual void Shoot(RaycastHit hit)
	{
		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
		{
			nextTimeToFire = Time.time + 1f / weaponStats.fireRate;
			SpawnProjectile(hit);
		}
	}
	public void SpawnProjectile(RaycastHit hit)
	{
		//GameObject proj = Instantiate(weaponStats.Projectile.gameObject, transform.position, Quaternion.identity);
		//proj.transform.forward = hit.point - transform.position;
		//proj.GetComponent<Rigidbody>().AddForce(proj.transform.forward * weaponStats.Projectile.speed);
	}
}
