﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
	public float speedMove;
	public float jumpPower;

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
			
			//TO DO:
		    _moveVector.x = Input.GetAxis("Horizontal") * speedMove;
		    _moveVector.z = Input.GetAxis("Vertical") * speedMove;

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

		if (Physics.Raycast(mousePos, out hit))
		{
			Vector3 rot = transform.eulerAngles;
			transform.LookAt(hit.point);
			Debug.DrawRay(transform.position, hit.point, Color.blue);
			transform.eulerAngles = new Vector3(rot.x, transform.eulerAngles.y, rot.z);
		}

		return hit;
    }

    private void Shoot(RaycastHit hit)
    {
	    if (Input.GetButtonDown("Fire1"))
	    {
		    Debug.Log(hit.transform.name);

		    Target target = hit.transform.GetComponent<Target>();
			if (target != null)
			{
				target.TakeDamage(Weapon.Damage);
			}

			Weapon.Shoot(hit);
	    }
    }

    private void Jump()
    {
	    if (!_controller.isGrounded) _gravityForce -= 20f * Time.deltaTime;
	    else _gravityForce = -1f;

	    if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
		    _gravityForce = jumpPower;
    }
}
