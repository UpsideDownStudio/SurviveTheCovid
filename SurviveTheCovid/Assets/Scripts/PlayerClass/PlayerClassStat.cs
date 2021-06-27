using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Class", menuName = "Player Class/ClassStat", order = 0)]
public class PlayerClassStat : ScriptableObject
{
	public int classId;
	public string name;

	public string titleOfFirstActiveSkill;
	public float cooldownOfFirstSkill;
	public string titleOfSecondActiveSkill;
	public float cooldownOfSecondSkill;

	public string titleOfFirstPassiveSkill;
	public string titleOfSecondPassiveSkill;
}
