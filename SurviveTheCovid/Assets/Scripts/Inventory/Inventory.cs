using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	//TODO: Переделать с Singleton на переменную в классе PlayerController
	#region Singleton

	public static Inventory instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.Log("More than one instance of Inventory found!");
			return;
		}

		instance = this;
	}

	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged OnItemChangedCallback;

	public int sizeOfInventory = 6;
	public List<Item> items = new List<Item>();

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
