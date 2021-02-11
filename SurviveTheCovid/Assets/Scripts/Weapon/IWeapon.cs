using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWeapon : MonoBehaviour
{
	public float FireRate;
	public IProjectile Projectile;
	public int WeaponIndex;

	public virtual void Shoot(RaycastHit hit)
	{
		GameObject proj = Instantiate(Projectile.gameObject, transform.position, Quaternion.identity);
		proj.transform.forward = hit.point - transform.position;
		proj.GetComponent<Rigidbody>().AddForce(proj.transform.forward * Projectile.Speed);
	}

}
