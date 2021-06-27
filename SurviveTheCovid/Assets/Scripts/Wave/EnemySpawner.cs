using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	public List<GameObject> easyEnemyList;
	public List<GameObject> mediumEnemyList;
	public List<GameObject> hardEnemyList;
	public List<GameObject> bossList;

	public void SpawnEnemy(int difficultyOfGame, List<Transform> spawnPoints)
	{
		switch (difficultyOfGame)
		{
			case 1:
				SpawnEasyWave(10,20, spawnPoints);
				break;
		}
	}

	private void SpawnEasyWave(int minAmount, int maxAmount, List<Transform> spawnPoints)
	{
		var randAmount = Random.Range(minAmount, maxAmount); //Выбирается кол-во врагов рандомно в заданном диапазоне
		Debug.Log(randAmount);
		var randAmountIndexOfEnemy = Random.Range(1, easyEnemyList.Count);
		List<int> indexOfEnemy = new List<int>();
		Dictionary<int, int> listOfEnemyAmountByIndex = new Dictionary<int, int>();

		AddToListRandomValue(randAmountIndexOfEnemy, indexOfEnemy, easyEnemyList);

		int rand = -1;
		for (int i = 0; i < indexOfEnemy.Count; i++)
		{
			if(randAmount > 0)
				rand = Random.Range(1, randAmount);

			if (i + 1 == indexOfEnemy.Count)
			{
				listOfEnemyAmountByIndex.Add(indexOfEnemy[i], randAmount);
			}
			else
			{
				listOfEnemyAmountByIndex.Add(indexOfEnemy[i], rand);
				randAmount -= rand;
			}
		}

		foreach (var i in listOfEnemyAmountByIndex)
		{
			Debug.Log("Key " + i.Key + " Value " + i.Value);
		}

		StartCoroutine(SpawnEnemyOnSpawnPoint(2f, spawnPoints, listOfEnemyAmountByIndex, easyEnemyList, 5));

		//Далее выбираются индексы врагов, которые будут заспавненны.
		//Далее из общего кол-во врагов - спавн определенного кол-во определенного типа врага.
		//Далее выбираются точки спавна (рандомно)
		//Через корутину сделать спавн нескольких врагов через определенное время.
		//Спавн врагов на точках.
	}


	private IEnumerator SpawnEnemyOnSpawnPoint(float time, List<Transform> spawnPoints, Dictionary<int, int> enemyByIndexDictionary, List<GameObject> enemyToSpawn, int countOfEnemy)
	{
		yield return new WaitForSeconds(time);
		var spawnPointAmount = Random.Range(1, spawnPoints.Count);
		List<int> spawnPointListByIndex = new List<int>();
		int spawnPointIndex = 0;
		AddToListRandomValue(spawnPointAmount, spawnPointListByIndex, spawnPoints);

		var enemyDictionary = enemyByIndexDictionary.Select(x => x.Key).ToList(); //получение всех ключей из словаря
		for (int i = 0; i < countOfEnemy; i++)
		{
			try
			{
				var rndEnemyIndex = Random.Range(0, enemyDictionary.Count-1);
				Instantiate(enemyToSpawn[enemyDictionary[rndEnemyIndex]], spawnPoints[spawnPointListByIndex[spawnPointIndex]].position, Quaternion.identity);
				enemyByIndexDictionary[enemyDictionary[rndEnemyIndex]] -= 1;
				spawnPointIndex++;
				if (spawnPointIndex > spawnPointListByIndex.Count - 1)
					spawnPointIndex = 0;

				if (enemyByIndexDictionary[enemyDictionary[rndEnemyIndex]] == 0)
				{
					enemyByIndexDictionary.Remove(enemyDictionary[rndEnemyIndex]);
					enemyDictionary = enemyByIndexDictionary.Select(x => x.Key).ToList(); //получение всех ключей из словаря
				}
			}
			catch (Exception e)
			{
				Debug.LogWarning(e);
			}
		}

		int count = enemyByIndexDictionary.Sum(x => x.Value);
		int difference = count - 5;

		if (difference > 0)
		{
			StartCoroutine(SpawnEnemyOnSpawnPoint(2f, spawnPoints, enemyByIndexDictionary, easyEnemyList, 5));
		}
		else if (count > 0)
		{
			StartCoroutine(SpawnEnemyOnSpawnPoint(2f, spawnPoints, enemyByIndexDictionary, easyEnemyList, count));
		}
	}

	private void AddToListRandomValue(int amount, List<int> toAddList, ICollection fromAddList)
	{
		while (amount != 0)
		{
			var index = Random.Range(0, fromAddList.Count-1);
			if (!(toAddList.Contains(index)))
			{
				toAddList.Add(index);
				amount--;
			}
		}
	}
}
