using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public abstract class PlayerClass : MonoBehaviour
{
	public PlayerClassStat playerClassStat;

	public abstract void UseFirstActiveSkill(); //Логика использования первого скила.
	public abstract void UseSecondActiveSkill(); //Логика использования второго скила.
	public abstract void UseFirstPassiveSkill(); //Логика использования первого пассивного скила.
	public abstract void UseSecondPassiveSkill(); //Логика использования второго пассивного скила.
}
