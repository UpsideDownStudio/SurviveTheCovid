﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public int indexOfItem;

	public Image icon;
	public Button removeButton;

	private Item _item;

	public void AddItem(Item newItem)
	{
		_item = newItem;

		icon.sprite = _item.icon;
		removeButton.interactable = true;
		icon.enabled = true;
	}

	public void ClearSlot()
	{
		_item = null;

		icon.sprite = null;
		removeButton.interactable = false;
		icon.enabled = false;
	}

	public void OnRemoveButton()
	{
		FindObjectOfType<PlayerInventory>().Remove(_item);
	}

	public void TakeAirDropItem()
	{
		if (_item != null)
		{
			_item.RemoveFromAirDropInventory();
		}
	}

	public void UseItem()
	{
		if (_item != null)
		{
			_item.Use();
		}
	}
}
