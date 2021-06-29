using Assets.Scripts.Weapon;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private PlayerMovementAnimation _playerMovement;
	private PlayerWeapon _playerWeapon;
	private CharacterController _characterController;
	private WeaponManager _weaponManager;
	private PlayerInventory _playerInventory;
	private PlayerStats _playerStats;

	public CharacterController CharacterController
	{
		get => _characterController;
		private set => _characterController = value;
	}
	public WeaponManager WeaponManager
	{
		get => _weaponManager;
		private set => _weaponManager = value;
	}
	public PlayerWeapon PlayerWeapon
	{
		get => _playerWeapon;
		private set => _playerWeapon = value;
	}
	public PlayerMovementAnimation PlayerMovement
	{
		get => _playerMovement;
		private set => _playerMovement = value;
	}
	public PlayerInventory PlayerInventory
	{
		get => _playerInventory;
		private set => _playerInventory = value;
	}

	public PlayerStats PlayerStats
	{
		get => _playerStats;
		private set => _playerStats = value;
	}


	// Start is called before the first frame update
	void Start()
    {
		PlayerMovement = GetComponent<PlayerMovementAnimation>();
		PlayerWeapon = GetComponent<PlayerWeapon>();
		CharacterController = GetComponent<CharacterController>();
		PlayerStats = GetComponent<PlayerStats>();
		WeaponManager = transform.GetChild(1).GetChild(0).GetComponent<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
