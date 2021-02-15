using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "ConfigEntity/Equipment")]
public class Equipment : Item
{
	public EquipmentSlot equipSlot;

	public override void Use()
	{
		base.Use();
		EquipmentManager.instance.Equip(this);
		RemoveFromInventory();
	}

	public int damageModifier;
	public int armorModifier;
}

public enum EquipmentSlot
{
	Head, 
	Chest,
	Legs,
	Weapon,
	Shield, 
	Feet
}