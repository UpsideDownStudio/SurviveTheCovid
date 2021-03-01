using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   
public class Stat
{
	[SerializeField] private float baseValue;

	[SerializeField] private List<float> modifiers = new List<float>();

	public float GetValue()
	{
		float finalValue = baseValue;
		modifiers.ForEach(m => finalValue += m);
		return finalValue;
	}

	public void AddModifiers(float modifier)
	{
		if (modifier != 0)
			modifiers.Add(modifier);
	}

	public void DeleteModifier(float modifier)
	{
		if (modifier != 0)
			modifiers.Remove(modifier);
	}
}
