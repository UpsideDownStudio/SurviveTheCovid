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
				_playerController.PlayerWeapon.SetWeapon(weaponStats.weaponIndex);
				damage.AddModifiers(weaponStats.damage);
				fireRate.AddModifiers(weaponStats.fireRate);
			}
		}
		
		if(oldItem != null)
		{
			WeaponStats weaponStats = oldItem as WeaponStats;
			if (weaponStats != null)
			{
				damage.DeleteModifier(weaponStats.damage);
				fireRate.DeleteModifier(weaponStats.fireRate);
			}
		}
	}	
}
