using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	private PlayerController _playerController;

	public delegate void OnItemChanged();
	public OnItemChanged OnItemChangedCallback;

	public int sizeOfInventory = 6;
	public List<Item> items = new List<Item>();

	private void Start()
	{
		_playerController = GetComponent<PlayerController>();
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
}
