using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Weapon", menuName = "ConfigEntity/Weapon", order = 0)]
public class WeaponStats : ScriptableObject
{
	[FormerlySerializedAs("_fireRate")] [SerializeField] private float fireRate;
	[FormerlySerializedAs("_projectile")] [SerializeField] private Projectile projectile;
	[FormerlySerializedAs("_weaponIndex")] [SerializeField] private int weaponIndex;
	//[SerializeField] private float _weaponDamageRadius;

	public float FireRate
	{
		get => fireRate;
	}

	public Projectile Projectile
	{
		get => projectile;
	}

	public int WeaponIndex
	{
		get => weaponIndex;
	}

	/*public float WeaponDamageRadius
	{
		get => _weaponDamageRadius
	}*/
}
