using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float Speed;
    
	private Animator anim;

	private CharacterController controller;

	private Vector3 playerVelocity;

	private float gravityValue = -9.81f;

	private bool _isShooting = false;

	private ShootHandler _shootHandler;


	public void Start()
	{
		controller = GetComponent<CharacterController>();
        _shootHandler = GetComponent<ShootHandler>();
        anim = GetComponent<Animator>();
	}

	public void FixedUpdate()
	{
		Move();
		HandleShoot();
	}

    public void Update()
    {
		HandleGravity();
		LookAtMouse();
	}

    private void LookAtMouse()
    {
		Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit cameraRayHit;

		if (Physics.Raycast(cameraRay, out cameraRayHit))
		{
			Vector3 targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
			transform.LookAt(targetPosition);
		}
	}

    private void Move()
    {
		var xInput = Input.GetAxisRaw("Horizontal");
		var zInput = Input.GetAxisRaw("Vertical");

        
		var move = new Vector3(xInput, 0.0f, 0.0f) + (zInput * transform.forward);

		HandleMovementAnimation(move);

        if (_isShooting is false)
        {
			controller.Move(move.normalized * Time.fixedDeltaTime * Speed);
        }
		else
        {
            controller.Move(move.normalized * Time.fixedDeltaTime * Speed * 0.5f);
        }
	}

    private void HandleMovementAnimation(Vector3 move)
    {
		if (move.z != 0 || move.x != 0)
		{
			anim.SetBool("IsRunning", true);
		}
		else
		{
			anim.SetBool("IsRunning", false);
		}
	}

	private void HandleGravity()
    {
		if (controller.isGrounded && playerVelocity.y < 0)
		{
			playerVelocity.y = 0f;
		}

		playerVelocity.y += gravityValue * Time.deltaTime;
		controller.Move(playerVelocity * Time.deltaTime);
	}

	private void HandleShoot()
    {
        if (Input.GetMouseButton(0))
        {
			_isShooting = true;
            _shootHandler.Shoot();
            anim.SetBool("IsShooting", true);
        }
		else
        {
            _isShooting = false;
            anim.SetBool("IsShooting", false);
        }
    }
}
