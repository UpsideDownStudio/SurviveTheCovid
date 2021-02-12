using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ConfigEntity/Weapon", order = 0)]
public class WeaponStats : ScriptableObject
{
	[SerializeField] private float _fireRate;
	[SerializeField] private IProjectile _projectile;
	[SerializeField] private int _weaponIndex;
	//[SerializeField] private float _weaponDamageRadius;

	public float FireRate
	{
		get => _fireRate;
	}

	public IProjectile Projectile
	{
		get => _projectile;
	}

	public int WeaponIndex
	{
		get => _weaponIndex;
	}

	/*public float WeaponDamageRadius
	{
		get => _weaponDamageRadius
	}*/
}
