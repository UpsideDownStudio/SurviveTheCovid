using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClassManager : MonoBehaviour
{
	public PlayerClass playerClass;

	[SerializeField] private float _currentCooldownTimeOfFirstSkill = 0f;
	[SerializeField] private float _currentCooldownTimeOfSecondSkill = 0f;

	private void Update()
	{
		UseFirstActiveSkill();
		UseSecondActiveSkill();
	}

	public void UseFirstActiveSkill()
	{
		if (Input.GetKeyDown(KeyCode.E) &&
		    _currentCooldownTimeOfFirstSkill >= playerClass.playerClassStat.cooldownOfFirstSkill)
		{
			playerClass.UseFirstActiveSkill();
			_currentCooldownTimeOfFirstSkill = 0;
		}
		else
		{
			_currentCooldownTimeOfFirstSkill += Time.deltaTime;
		}
	}

	public void UseSecondActiveSkill()
	{
		if (Input.GetKeyDown(KeyCode.Q) &&
		    _currentCooldownTimeOfSecondSkill >= playerClass.playerClassStat.cooldownOfSecondSkill)
		{
			playerClass.UseSecondActiveSkill();
			_currentCooldownTimeOfSecondSkill = 0;
		}
		else
		{
			_currentCooldownTimeOfSecondSkill += Time.deltaTime;
		}
	}
}
