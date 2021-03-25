using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDropHandler, IDragHandler, IEndDragHandler
{
	private CanvasGroup _canvasGroup;
	private int _indexOfItem;
	private PlayerInventory _playerInventory;

	void Start()
	{
		_playerInventory = FindObjectOfType<PlayerInventory>();
		_canvasGroup = GetComponent<CanvasGroup>();
		_indexOfItem = transform.parent.parent.GetComponent<InventorySlot>().indexOfItem;
	}
	public void OnBeginDrag(PointerEventData eventData)
	{
		_canvasGroup.alpha = .6f;
		_canvasGroup.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
    {
	    transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
	    transform.localPosition = Vector3.zero;
	    _canvasGroup.alpha = 1f;
	    _canvasGroup.blocksRaycasts = true;
	}

    public void OnDrop(PointerEventData eventData)
    {
	    int indexOfHoveredItem =
		    eventData.pointerDrag.transform.parent.parent.GetComponent<InventorySlot>().indexOfItem;
		if (_indexOfItem != -1 && indexOfHoveredItem != -1)
			_playerInventory.Switch(_indexOfItem, indexOfHoveredItem);
    }
}
