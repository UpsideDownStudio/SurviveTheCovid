using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
	public static int CountOfEnemy;

	public Text textOfWaveTimer;
	public Text textOfTimeNextWave;
	public Text textOfWaveCountEnemy;

	public EnemySpawner enemySpawner;
	public List<Transform> spawnPointsList;

	private float _waveTimer;
	private float _timeNextWave;

	public void Start()
	{
		enemySpawner.SpawnEnemy(1, spawnPointsList);
	}
}
