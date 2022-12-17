using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class OnPlayerDeath : UnityEvent
{
}

public class PlayerController : MonoBehaviour
{
    public OnPlayerDeath OnPlayerDeath;

    [SerializeField]
    private float _healDelaySeconds = 10f;
    private float _healTimer = 0f;

    private PlayerStats _stats;

    private Animator anim;

    private CharacterController controller;

    private Vector3 playerVelocity;

    private bool _isShooting = false;

    private ShootHandler _shootHandler;

    private Vector3 _startingPos;


    public void Awake()
    {
        controller = GetComponent<CharacterController>();
        _shootHandler = GetComponent<ShootHandler>();
        anim = GetComponent<Animator>();
        _stats = GetComponent<PlayerStats>();
    }

    public void Start()
    {
        _startingPos = transform.localPosition;
    }

    public void FixedUpdate()
    {
        if (StateManager.Instance().CurrentState != State.Game)
        {
            anim.SetBool("IsRunning", false);
            return;
        }

        Move();
        HandleShoot();
    }

    public void Update()
    {
        if (_stats.Hp <= 0)
        {
            OnPlayerDeath.Invoke();
        }

        HandleGravity();

        if (StateManager.Instance().CurrentState != State.Game)
        {
            return;
        }

        LookAtMouse();

        if (Time.time > _healTimer)
        {
            _healTimer = Time.time + _healDelaySeconds;
            HandleHeal();
        }
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
            controller.Move(move.normalized * Time.fixedDeltaTime * _stats.Speed);
        }
        else
        {
            controller.Move(move.normalized * Time.fixedDeltaTime * _stats.Speed * 0.5f);
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

        playerVelocity.y += -9.81f * Time.deltaTime;
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

    public void Reset()
    {
        gameObject.SetActive(false);
        transform.localPosition = _startingPos;
        gameObject.SetActive(true);
        _stats.Reset();
    }

    public void TakeDamage(float damage)
    {
        _stats.Hp -= damage;
    }

    private void HandleHeal()
    {
        if (_stats.Hp < _stats.MaxHp)
        {

            _stats.Hp += 1;
        }
    }
}
