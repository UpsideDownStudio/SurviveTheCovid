﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWeapon : MonoBehaviour
{
	public float FireRate;
	public IProjectile Projectile;

	public virtual void Shoot(RaycastHit hit) {}
	
}