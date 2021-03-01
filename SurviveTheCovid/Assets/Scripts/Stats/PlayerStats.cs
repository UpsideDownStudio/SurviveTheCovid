using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
	public WeaponStats weaponStats;
	private EquipmentManager _equipmentManager;

    void Start()
    {
		_equipmentManager = FindObjectOfType<EquipmentManager>();
        _equipmentManager.onEquipmentChanged += OnEquipmentChanged;
    }

	private void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if(newItem != null)
		{
			weaponStats = newItem as WeaponStats;
			if(weaponStats != null)
			{
				Debug.Log("Weapon is not null " + weaponStats.damage);
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
