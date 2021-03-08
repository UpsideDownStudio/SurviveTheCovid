using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
	[SerializeField] private float baseValue;

	[SerializeField] private List<float> modifiers = new List<float>();

	private int indexOfWeaponModifier;

	public float GetValue()
	{
		float finalValue = baseValue;
		modifiers.ForEach(m => finalValue += m);
		return finalValue;
	}

	public void AddModifiers(float modifier, bool isWeapon = false)
	{
		if (modifier != 0)
			modifiers.Add(modifier);

		if (isWeapon)
			indexOfWeaponModifier = modifiers.Count-1;
	}

	public void DeleteModifier(float modifier)
	{
		if (modifier != 0)
			modifiers.Remove(modifier);
	}

	public void SwitchModifier(float modifier)
	{
		if (modifier != null)
			modifiers[indexOfWeaponModifier] = modifier;
	}
}
