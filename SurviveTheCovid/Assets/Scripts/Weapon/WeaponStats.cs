using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Weapon", menuName = "ConfigEntity/Weapon", order = 0)]
public class WeaponStats : Equipment
{
	public int weaponIndex;
	public float fireRate;
	public float damage;
	public float speedProjectile;
	public GameObject projectile;

	public override void Use()
	{
		base.Use();
		FindObjectOfType<EquipmentManager>().Equip(this);
		RemoveFromInventory();
	}
}
