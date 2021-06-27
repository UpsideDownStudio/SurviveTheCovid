using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AirDropBox : MonoBehaviour
{
	public int sizeOfInventory = 6;
	[SerializeField] private List<Item> _items = new List<Item>();

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
		return rndCapacity;
	}

	public void AddItemsToBoxInventory(List<Item> items)
	{
		_items = new List<Item>();
		foreach (var item in items)
		{
			_items.Add(item);
		}
	}

	public void RemoveItemsFromBoxInventory(Item item)
	{
		if (FindObjectOfType<PlayerInventory>().Add(item))
		{
			_items.Remove(item);
			_airDropUi.UpdateUi(_items);
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
			UpdateAirDropUi(_items);
			_airDropUi.CurrentAirDropBox = this;
			_airDropUi.inventoryUi.SetActive(true);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			_airDropUi.inventoryUi.SetActive(false);
			_airDropUi.CurrentAirDropBox = null;
		}
	}
}
