using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryUi : MonoBehaviour
{
	public Transform itemsParent;
	[FormerlySerializedAs("inventoryUI")] public GameObject inventoryUi;

	private Inventory _inventory;
	private InventorySlot[] _slots;

	private void Start()
	{
		_inventory = Inventory.Instance;
		_inventory.OnItemChangedCallback += UpdateUi;

		_slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}

	private void Update()
	{
		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUi.SetActive(!inventoryUi.activeSelf);
		}

	}

	void UpdateUi()
	{
		for (int i = 0; i < _slots.Length; i++)
		{
			if (i < _inventory.items.Count)
			{
				_slots[i].AddItem(_inventory.items[i]);
			}
			else
			{
				_slots[i].ClearSlot();
			}
		}
	}
}
