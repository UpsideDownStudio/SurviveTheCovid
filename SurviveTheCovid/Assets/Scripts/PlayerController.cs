using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
	//TODO: Сделать отдельные классы стрельбы, хождения.

	private PlayerMovement _playerMovement;
	private PlayerShooting _playerShooting;
	private CharacterController _characterController;
	private WeaponManager _weaponManager;
	private PlayerInventory _playerInventory;

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
	public PlayerShooting PlayerShooting
	{
		get => _playerShooting;
		private set => _playerShooting = value;
	}
	public PlayerMovement PlayerMovement
	{
		get => _playerMovement;
		private set => _playerMovement = value;
	}
	public PlayerInventory PlayerInventory
	{
		get => _playerInventory;
		private set => _playerInventory = value;
	}


	// Start is called before the first frame update
	void Start()
    {
		PlayerMovement = GetComponent<PlayerMovement>();
		PlayerShooting = GetComponent<PlayerShooting>();
		CharacterController = GetComponent<CharacterController>();
	    WeaponManager = transform.GetChild(1).GetChild(0).GetComponent<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
