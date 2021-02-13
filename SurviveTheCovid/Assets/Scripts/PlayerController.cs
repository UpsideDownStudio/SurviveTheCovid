using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.WSA;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
	public float SpeedMove;
	public float JumpPower;

	public Weapon Weapon;

	private float _gravityForce;
	private Vector3 _moveVector;

	private CharacterController _controller;
	private WeaponManager _weaponManager;

    // Start is called before the first frame update
    void Start()
    {
	    _controller = GetComponent<CharacterController>();
	    _weaponManager = transform.GetChild(1).GetChild(0).GetComponent<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
		Shoot(LookAt());
        MoveCharacter();
        Jump();
    }

    private void MoveCharacter()
    {
	    if (_controller.isGrounded)
	    {
		    _moveVector = Vector3.zero;

		    _moveVector.x = Input.GetAxis("Horizontal") * SpeedMove;
		    _moveVector.z = Input.GetAxis("Vertical") * SpeedMove;
	    }

	    _moveVector.y = _gravityForce;
	    _controller.Move(_moveVector * Time.deltaTime); //Передвижение по направлению
    }

    private RaycastHit LookAt()
    {
	    Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();

		Vector3 objPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Physics.Raycast(mousePos, out hit))
		{
			Vector3 rot = transform.eulerAngles;

			Quaternion targetRotation = Quaternion.LookRotation(hit.point - transform.position);
			targetRotation.x = 0;
			targetRotation.z = 0;
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
			Debug.DrawRay(transform.position, hit.point - transform.position, Color.blue);
		}

		return hit;
    }

    private void Shoot(RaycastHit hit)
    {
	    Weapon.Shoot(hit);
    }

    private void Jump()
    {
	    if (!_controller.isGrounded) _gravityForce -= 20f * Time.deltaTime;
	    else _gravityForce = -1f;

	    if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
		    _gravityForce = JumpPower;
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Weapon"))
		{
			Debug.Log("Weapon: " + other.name);
			//other.GetComponent<Weapon>().Interact();
			//Destroy(other.gameObject);
		}
	}

}
