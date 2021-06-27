using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
	public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
	public event OnEquipmentChanged onEquipmentChanged;

	private Equipment[] currentEquipment;
	private PlayerInventory _playerInventory;

	private void Start()
	{
		_playerInventory = FindObjectOfType<PlayerInventory>();

		int equipmentCount = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
		currentEquipment = new Equipment[equipmentCount];
	}

	public void Equip(Equipment newItem)
	{
		int equipmentSlotIndex = (int)newItem.equipSlot;
		Equipment oldItem = null;

		if(currentEquipment[equipmentSlotIndex] != null)
		{
			oldItem = currentEquipment[equipmentSlotIndex];
			_playerInventory.Add(oldItem);
		}

		onEquipmentChanged?.Invoke(newItem, oldItem);

		currentEquipment[equipmentSlotIndex] = newItem;
	}

	public void Unequip(int equipmentIndex)
	{
		if (currentEquipment[equipmentIndex] != null)
		{
			Equipment oldItem = currentEquipment[equipmentIndex];
			_playerInventory.Add(oldItem);

			onEquipmentChanged?.Invoke(null, oldItem);

			currentEquipment[equipmentIndex] = null;
		}
	}

	public void UnequipAll()
	{
		for(int i = 0; i < currentEquipment.Length; i++)
		{
			Unequip(i);
		}
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.U))
		{
			UnequipAll();
		}
	}
}
