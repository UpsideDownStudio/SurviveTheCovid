using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDropInventory : MonoBehaviour
{
	[SerializeField] private int _inventoryCapacity;
	[SerializeField] private List<Item> _boxInventoryList;

	[SerializeField] private GameObject _airDrop;
	private AirDropUI _airDropUi;

	void Start()
	{
		_airDrop = GameObject.Find("Canvas");
		_airDropUi = _airDrop.GetComponent<AirDropUI>();
	}

	public int GenerateInventoryCapacity()
	{
		//Генерация за счёт сложности игры + личных навыков + продолжительности игры + (возможно покупка расходников, с увеличенным кол-во вместимости)
		int minChance = 1; //Пока так, в дальнейшем скалирование из-за всех выше перечисленных аттрибутов.
		int maxChance = 3; //Пока так, в дальнейшем скалирование из-за всех выше перечисленных аттрибутов.

		var rndCapacity = Random.Range(minChance, maxChance);
		_inventoryCapacity = rndCapacity;
		return _inventoryCapacity;
	}

	public void AddItemsToBoxInventory(List<Item> items)
	{
		_boxInventoryList = new List<Item>();
		foreach (var item in items)
		{
			_boxInventoryList.Add(item);
		}
	}

	public void UpdateAirDropUi(List<Item> items) 
	{
		_airDropUi.UpdateUi(items);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			UpdateAirDropUi(_boxInventoryList);
			_airDropUi.inventoryUi.SetActive(true);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			_airDropUi.inventoryUi.SetActive(false);
		}
	}
}
