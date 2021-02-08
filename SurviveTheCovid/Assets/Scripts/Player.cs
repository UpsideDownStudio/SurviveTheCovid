using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
	public float SpeedMove;
	public float JumpPower;

	public IWeapon Weapon;

	private float _gravityForce;
	private Vector3 _moveVector;

	private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
	    _controller = GetComponent<CharacterController>();
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

		    /* Поворот игрока в сторону движения
	        if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
	        {
		        Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, speedMove, 0.0f);
		        transform.rotation = Quaternion.LookRotation(direct);
	        }
		    */
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
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 4f * Time.deltaTime);
			Debug.DrawRay(transform.position, hit.point - transform.position, Color.blue);
		}

		return hit;
    }

    private void Shoot(RaycastHit hit)
    {
	    if (Input.GetButtonDown("Fire1"))
	    {
			Weapon.Shoot(hit);
	    }
    }

    private void Jump()
    {
	    if (!_controller.isGrounded) _gravityForce -= 20f * Time.deltaTime;
	    else _gravityForce = -1f;

	    if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
		    _gravityForce = JumpPower;
    }
}
