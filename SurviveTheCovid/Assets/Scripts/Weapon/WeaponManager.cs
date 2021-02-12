using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called before the first frame update
    public IWeapon CurrentWeapon;
    public List<int> WeaponsIndex;

    [SerializeField]
    private Player _player;
    [SerializeField]
    private int _currentWeaponIndex = 0;

    void Start()
    {
	    _player = transform.parent.parent.GetComponent<Player>();
        SetWeapon();
    }

    void Update()
    {
        SwitchWeapon();
    }

    private void SetWeapon(int index = 0)
    {
       if (WeaponsIndex.IndexOf(index) != -1)
       {
	       CurrentWeapon = transform.GetChild(index).GetComponent<IWeapon>();
	       _player.Weapon = CurrentWeapon;
       }
    }

    public void SwitchWeapon()
    {
	    if (Input.GetKeyDown(KeyCode.R))
	    {
		    _currentWeaponIndex++;
		    if (WeaponsIndex.Count-1 < _currentWeaponIndex)
		    {
			    _currentWeaponIndex = 0;
		    }
		    SetWeapon(WeaponsIndex[_currentWeaponIndex]);
	    }
    }

    public void TakeWeapon(int index)
    {
        if(WeaponsIndex.IndexOf(index) == -1)
	        WeaponsIndex.Add(index);
    }
}
