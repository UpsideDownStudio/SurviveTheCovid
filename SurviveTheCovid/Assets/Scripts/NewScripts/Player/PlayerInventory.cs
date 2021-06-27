using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	private PlayerController _playerController;
	private InventoryUI _inventoryUi;

	public delegate void OnItemChanged();
	public OnItemChanged OnItemChangedCallback;

	public int sizeOfInventory = 6;
	public List<Item> items = new List<Item>();

	private void Start()
	{
		_playerController = GetComponent<PlayerController>();
		_inventoryUi = FindObjectOfType<InventoryUI>();

		for (int i = 0; i < _inventoryUi.itemsParent.childCount; i++)
		{
			_inventoryUi.itemsParent.GetChild(i).GetComponent<InventorySlot>().indexOfItem = i;
		}
	}

	public bool Add(Item item)
    {
	    if (!item.isDefaultItem)
	    {
		    if (items.Count >= sizeOfInventory)
		    {
				Debug.Log("Not enough space");
				return false;
		    }

		    items.Add(item);
		    OnItemChangedCallback?.Invoke();
		}

	    return true;
    }

    public void Remove(Item item)
    {
	    items.Remove(item);
	    OnItemChangedCallback?.Invoke();
	}

    public void Switch(int firstItem, int secondItem)
    {
	    var tmpItem = items[firstItem];
	    items[firstItem] = items[secondItem];
	    items[secondItem] = tmpItem;

	    OnItemChangedCallback?.Invoke();
	}
}
