using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabManager : MonoBehaviour
{
	public Transform dragPoint;

	[SerializeField] private GameObject dragItem;
	private PlayerController _playerController;
	private void Start()
	{
		_playerController = GetComponent<PlayerController>();
	}

	void Update()
	{
		Drag();
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Draggable"))
		{
			if (Input.GetKey(KeyCode.F))
			{
				dragItem = other.gameObject;
			}
		}
	}

	private void Drag()
	{
		if (dragItem != null)
		{
			if (Input.GetKey(KeyCode.F))
			{
				dragItem.transform.SetParent(dragPoint);
				dragItem.gameObject.transform.position = dragPoint.position;
				dragItem.GetComponent<Rigidbody>().isKinematic = true;
				dragItem.GetComponent<Rigidbody>().useGravity = false;
			}
			else
			{
				dragItem.transform.parent = null;
				dragItem.GetComponent<Rigidbody>().isKinematic = false;
				dragItem.GetComponent<Rigidbody>().useGravity = true;

				dragItem = null;
			}
		}
	}
}
