using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;

    // Start is called before the first frame update
    public Weapon currentWeapon;
    public List<Weapon> weapons = new List<Weapon>();
    public List<int> weaponsIndex = new List<int>();

    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private int currentWeaponIndex = 0;

    private void Awake()
    {
	    if (Instance != null)
	    {
            Debug.LogWarning("More than one instance of WeaponManager found!");
            return;
	    }

	    Instance = this;
    }

    void Start()
    {
	    _playerController = transform.parent.parent.GetComponent<PlayerController>();
        SetWeapon();
    }

    void Update()
    {
        SwitchWeapon();
    }

    private void SetWeapon(Weapon weapon = null)
    {
	    if (currentWeapon == null)
	    {
		    currentWeapon = weapons[0];
	    }
	    else
	    {
		    currentWeapon = weapon;
	    }

	    _playerController.PlayerShooting.weapon = currentWeapon;
    }

    public void SwitchWeapon()
    {
	    if (Input.GetKeyDown(KeyCode.R))
	    {
		    currentWeaponIndex++;
		    if (weapons.Count-1 < currentWeaponIndex)
		    {
			    currentWeaponIndex = 0;
		    }
		    SetWeapon(weapons[currentWeaponIndex]);
	    }
    }

    public void AddWeapon(Weapon weapon)
    {
	    weapons.Add(weapon);
    }
}
