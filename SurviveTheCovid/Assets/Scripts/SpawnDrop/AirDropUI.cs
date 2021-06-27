using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDropUI : MonoBehaviour
{
	public Transform itemsParent;
	public GameObject inventoryUi;
	public AirDropBox CurrentAirDropBox;

	private InventorySlot[] _slots;

	private void Start()
	{
		_slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}

	public void UpdateUi(List<Item> listOfItems)
	{
		for (int i = 0; i < _slots.Length; i++)
		{
			if (i < listOfItems.Count)
			{
				_slots[i].AddItem(listOfItems[i]);
			}
			else
			{
				_slots[i].ClearSlot();
			}
		}
	}
}
