using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

	private void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if(newItem != null)
		{
			damage.AddModifiers(newItem.damageModifier);
			armor.AddModifiers(newItem.armorModifier);
		}
		
		if(oldItem != null)
		{
			damage.DeleteModifier(oldItem.damageModifier);
			armor.DeleteModifier(oldItem.armorModifier);
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
