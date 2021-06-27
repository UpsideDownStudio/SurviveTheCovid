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
	}
}

public enum EquipmentSlot
{
	Weapon
}