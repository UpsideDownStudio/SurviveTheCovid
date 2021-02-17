using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
	public WeaponStats weaponStats;

    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

	private void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if(newItem != null)
		{
			WeaponStats weaponStats = newItem as WeaponStats;
			if(weaponStats != null)
			{
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
