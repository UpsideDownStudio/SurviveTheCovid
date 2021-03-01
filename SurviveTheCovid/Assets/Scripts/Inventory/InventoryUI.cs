using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryUI : MonoBehaviour
{
	public Transform itemsParent;
	[FormerlySerializedAs("inventoryUI")] public GameObject inventoryUi;

	private PlayerInventory _playerInventory;
	private InventorySlot[] _slots;

	private void Start()
	{
		_playerInventory = FindObjectOfType<PlayerInventory>();
		_playerInventory.OnItemChangedCallback += UpdateUi;

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
			if (i < _playerInventory.items.Count)
			{
				_slots[i].AddItem(_playerInventory.items[i]);
			}
			else
			{
				_slots[i].ClearSlot();
			}
		}
	}
}
