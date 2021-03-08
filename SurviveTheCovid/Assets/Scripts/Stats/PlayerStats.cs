using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
	private EquipmentManager _equipmentManager;
	private PlayerController _playerController;

    void Start()
    {
	    _playerController = GetComponent<PlayerController>();
		_equipmentManager = FindObjectOfType<EquipmentManager>();
        _equipmentManager.onEquipmentChanged += OnEquipmentChanged;
    }

	private void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if(newItem != null)
		{
			var weaponStats = newItem as WeaponStats;
			if(weaponStats != null)
			{
				_playerController.PlayerWeapon.AddWeapon(weaponStats.weaponIndex);
				//damage.AddModifiers(weaponStats.damage);
				//fireRate.AddModifiers(weaponStats.fireRate);
			}
		}

		if(oldItem != null)
		{
			//WeaponStats weaponStats = oldItem as WeaponStats;
			//if (weaponStats != null)
			//{
			//	damage.DeleteModifier(weaponStats.damage);
			//	fireRate.DeleteModifier(weaponStats.fireRate);
			//}
		}
	}

	public void SwitchWeapon(WeaponStats newWeapon)
	{
		ChangeWeaponState(newWeapon);
	}

	public void InitializeWeapon(WeaponStats weapon)
	{
		if (weapon != null)
		{
			damage.AddModifiers(weapon.damage);
			fireRate.AddModifiers(weapon.fireRate);
		}
	}

	private void ChangeWeaponState(WeaponStats newWeapon)
	{
		if (newWeapon != null)
		{
			damage.SwitchModifier(newWeapon.damage);
			fireRate.SwitchModifier(newWeapon.fireRate);
		}
	}
}
