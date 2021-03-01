using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speedMove;
	public float jumpPower;

	private float _gravityForce;
	private Vector3 _moveVector;

	private PlayerController _playerController;

    void Start()
    {
		_playerController = GetComponent<PlayerController>();	    
    }

	private void Update()
	{
		Move();
		LookAround();
	}
	private void Move()
	{
		MoveCharacter();
		Jump();
	}

	private void MoveCharacter()
	{
		if (_playerController.CharacterController.isGrounded)
		{
			_moveVector = Vector3.zero;

			_moveVector.x = Input.GetAxis("Horizontal") * speedMove;
			_moveVector.z = Input.GetAxis("Vertical") * speedMove;
		}

		_moveVector.y = _gravityForce;
		_playerController.CharacterController.Move(_moveVector * Time.deltaTime); //Передвижение по направлению
	}

	private void LookAround()
	{
		Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();

		if (Physics.Raycast(mousePos, out hit))
		{
			Quaternion targetRotation = Quaternion.LookRotation(hit.point - transform.position);
			targetRotation.x = 0;
			targetRotation.z = 0;
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
			Debug.DrawRay(transform.position, hit.point - transform.position, Color.blue);
		}
	}

	private void Jump()
	{
		if (!_playerController.CharacterController.isGrounded) _gravityForce -= 20f * Time.deltaTime;
		else _gravityForce = -1f;

		if (Input.GetKeyDown(KeyCode.Space) && _playerController.CharacterController.isGrounded)
			_gravityForce = jumpPower;
	}

}
