using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
	public List<Weapon> weaponList;
	public GameObject weaponInventory;

	[SerializeField] private Weapon _currentWeapon;
	private PlayerController _playerController;
	[SerializeField] private int _currentWeaponListIndex;

    private void Start()
    {
	    _currentWeapon = weaponList[0];
	    _currentWeaponListIndex = 0;
		_playerController = GetComponent<PlayerController>();
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

	public void SetWeapon(int index)
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

			_currentWeapon = weaponList[index];
			_currentWeaponListIndex = index;
		}
	}
}
