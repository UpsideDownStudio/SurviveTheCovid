using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWeapon : MonoBehaviour
{
	public float Damage;
	public float Range;
	public float FireRate;
	public GameObject Projectile;
	public virtual void Shoot(RaycastHit hit) {}
}
