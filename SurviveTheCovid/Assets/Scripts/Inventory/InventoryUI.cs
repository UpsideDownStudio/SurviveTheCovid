using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	public Transform itemsParent;
	public GameObject inventoryUI;

	private Inventory _inventory;
	private InventorySlot[] slots;

	private void Start()
	{
		_inventory = Inventory.instance;
		_inventory.OnItemChangedCallback += UpdateUI;

		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}

	private void Update()
	{
		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}

	}

	void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < _inventory.items.Count)
			{
				slots[i].AddItem(_inventory.items[i]);
			}
			else
			{
				slots[i].ClearSlot();
			}
		}
	}
}
