using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
	public List<Weapon> weaponList;
	public GameObject weaponInventory;

	private Weapon _currentWeapon;
	private PlayerController _playerController;
	private int _currentWeaponListIndex;

    private void Start()
    {
	    _currentWeapon = weaponList[0];
	    _currentWeaponListIndex = 0;

	    _playerController = GetComponent<PlayerController>();
	    _playerController.PlayerStats.InitializeWeapon(_currentWeapon.weaponStats);
	}

	private void Update()
	{
		Shoot();
		SwitchWeapon();
	}

	private void Shoot()
	{
		Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();

		if (Physics.Raycast(mousePos, out hit))
		{
			_currentWeapon.Shoot(hit);
		}
	}

	public void AddWeapon(int index)
	{
		_currentWeaponListIndex++;

		if (_currentWeaponListIndex > 1)
			_currentWeaponListIndex = 0;

		weaponList[_currentWeaponListIndex] = weaponInventory.transform.GetChild(index).GetComponent<Weapon>();
		_currentWeapon = weaponList[_currentWeaponListIndex];
	}

	private void SwitchWeapon()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			var index = _currentWeaponListIndex;
			Debug.Log(index);
			index++;
			if (index > 1)
				index = 0;

			if (weaponList[index] != null)
			{
				_currentWeapon = weaponList[index];
				_currentWeaponListIndex = index;
				_playerController.PlayerStats.SwitchWeapon(_currentWeapon.weaponStats);
			}
			else
			{
				index--;
			}
		}
	}
}
