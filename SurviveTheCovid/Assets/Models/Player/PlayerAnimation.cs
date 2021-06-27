using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
	private const float locomationAnimationSmoothTime = .1f;

	private PlayerMovement _playerMovement;
	private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
	    _playerMovement = GetComponent<PlayerMovement>();
	    _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
	    float speedPercent = _playerMovement.moveVector.magnitude / _playerMovement.speedMove;
        _animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);
    }
}
