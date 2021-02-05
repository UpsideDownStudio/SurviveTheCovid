using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pistol : IWeapon
{
	public override void Shoot(RaycastHit hit)
	{
		GameObject proj = Instantiate(Projectile, transform.position, Quaternion.identity);
		proj.transform.forward = hit.point.normalized;
		proj.GetComponent<Rigidbody>().AddForce(hit.point * 10f, ForceMode.Impulse);
	}
}
