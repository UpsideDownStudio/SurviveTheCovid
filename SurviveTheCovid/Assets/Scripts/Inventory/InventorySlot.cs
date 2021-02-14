using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
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
		Inventory.Instance.Remove(_item);
	}

	public void UseItem()
	{
		if (_item != null)
		{
			_item.Use();
		}
	}
}
