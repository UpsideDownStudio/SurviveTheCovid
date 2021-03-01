using System.Security.Cryptography;
using UnityEngine;

public class ItemPickup : Interactable
{
	public Item item;
	public override void Interact()
	{
		PickUp();
	}

	private void PickUp()
	{
		Debug.Log("Picking up " + item.name);
		if(FindObjectOfType<PlayerInventory>().Add(item)) //If item was picked up than destroy the object
			Destroy(gameObject);
	}
}
