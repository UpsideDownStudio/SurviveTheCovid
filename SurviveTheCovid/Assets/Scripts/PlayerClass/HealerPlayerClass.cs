using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerPlayerClass : PlayerClass
{
	public override void UseFirstActiveSkill()
	{
		Debug.Log(playerClassStat.titleOfFirstActiveSkill + playerClassStat.cooldownOfFirstSkill);
	}

	public override void UseSecondActiveSkill()
	{
		Debug.Log(playerClassStat.titleOfSecondActiveSkill + playerClassStat.cooldownOfSecondSkill);
	}

	public override void UseFirstPassiveSkill()
	{
		throw new System.NotImplementedException();
	}

	public override void UseSecondPassiveSkill()
	{
		throw new System.NotImplementedException();
	}
}
