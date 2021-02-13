using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponManager : MonoBehaviour
{
	public static WeaponManager instance;

	// Start is called before the first frame update
    public Weapon CurrentWeapon;
    public List<Weapon> Weapons = new List<Weapon>();
    public List<int> WeaponsIndex = new List<int>();

    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private int _currentWeaponIndex = 0;

    private void Awake()
    {
	    if (instance != null)
	    {
            Debug.LogWarning("More than one instance of WeaponManager found!");
            return;
	    }

	    instance = this;
    }

    void Start()
    {
	    playerController = transform.parent.parent.GetComponent<PlayerController>();
        SetWeapon();
    }

    void Update()
    {
        SwitchWeapon();
    }

    private void SetWeapon(Weapon weapon = null)
    {
	    if (CurrentWeapon == null)
	    {
		    CurrentWeapon = Weapons[0];
	    }
	    else
	    {
		    CurrentWeapon = weapon;
	    }

	    playerController.Weapon = CurrentWeapon;
    }

    public void SwitchWeapon()
    {
	    if (Input.GetKeyDown(KeyCode.R))
	    {
		    _currentWeaponIndex++;
		    if (Weapons.Count-1 < _currentWeaponIndex)
		    {
			    _currentWeaponIndex = 0;
		    }
		    SetWeapon(Weapons[_currentWeaponIndex]);
	    }
    }

    public void AddWeapon(Weapon weapon)
    {
	    Weapons.Add(weapon);
    }
}
