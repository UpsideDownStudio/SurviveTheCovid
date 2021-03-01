using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public Weapon weapon;
    private PlayerController _playerController;

	private void Start()
	{
		_playerController = GetComponent<PlayerController>();
	}

	private void Update()
	{
		Shoot();
	}

	private void Shoot()
	{
		Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();

		if (Physics.Raycast(mousePos, out hit))
		{
			weapon.Shoot(hit);
		}

	}
}
