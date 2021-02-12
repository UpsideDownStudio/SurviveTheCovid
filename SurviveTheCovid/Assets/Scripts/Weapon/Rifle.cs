using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : IWeapon
{
	public override void Shoot(RaycastHit hit)
	{
		if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire)
		{
			_nextTimeToFire = Time.time + 1f / WeaponStats.FireRate;
			SpawnProjectile(hit);
		}
	}
}
