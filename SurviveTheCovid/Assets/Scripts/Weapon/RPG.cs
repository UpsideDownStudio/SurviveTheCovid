using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG : IWeapon
{
	public override void Shoot(RaycastHit hit)
	{
		GameObject proj = Instantiate(Projectile.gameObject, transform.position, Quaternion.identity);
		proj.transform.forward = hit.point - transform.position;
		proj.GetComponent<Rigidbody>().AddForce(proj.transform.forward * Projectile.Speed);
	}
}
