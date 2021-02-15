﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   
public class Stat
{
	[SerializeField] private int baseValue;

	private List<int> modifiers = new List<int>();

	public int GetValue()
	{
		int finalValue = baseValue;
		modifiers.ForEach(m => finalValue += m);
		return finalValue;
	}

	public void AddModifiers(int modifier)
	{
		if (modifier != 0)
			modifiers.Add(modifier);
	}

	public void DeleteModifier(int modifier)
	{
		if (modifier != 0)
			modifiers.Remove(modifier);
	}
}
