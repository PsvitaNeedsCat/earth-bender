﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Public
    public float drag = 2.0f;
    public float punchCooldownMax = 1.0f;
    public Animator playerAnimator;

    // Private
    InputMaster controls;
    PlayerController playerController;
    Vector2 playerDirection = new Vector2(0.0f, 0.0f);
    Rigidbody m_rigidBody;
    float punchCooldown = 0.0f;
    private float playerGravity = -300.0f;
    private bool moveDisabled = false;

    private void OnDestroy()
    {
        controls.Disable();
    }

    private void Awake()
    {
        // Init stuff
        controls = new InputMaster();
        controls.Player.Enable();
        m_rigidBody = GetComponent<Rigidbody>();

        playerController = GetComponent<PlayerController>();

        // Controls //
        // Movement
        controls.Player.Movement.performed += ctx => playerDirection = ctx.ReadValue<Vector2>();
        controls.Player.KeyboardHorizontal.performed += ctx => playerDirection.x = ctx.ReadValue<float>();
        controls.Player.KeyboardVertical.performed += ctx => playerDirection.y = ctx.ReadValue<float>();
        // Punch attack
        // controls.Player.AttackPress.performed += _ => AttemptPunch();
        controls.Player.AttackPress.performed += _ => StartPunch();
        controls.Player.ChargePress.performed += _ => playerController.ActivateTileTargeter();
        controls.Player.ChargeRelease.performed += _ => playerController.DeactivateTileTargeter();
        // controls.Player.ChargeRelease.performed += _ => playerController.TryRaiseChunk();
        controls.Player.ChargeRelease.performed += _ => StartRaiseChunk();
    }

    private void FixedUpdate()
    {
        MovePlayer();

        // Manual Drag (X and Z)
        Vector3 vel = m_rigidBody.velocity;
        vel.x *= (0.98f / drag);
        vel.z *= (0.98f / drag);
        m_rigidBody.velocity = vel;

        // Manual gravity
        m_rigidBody.AddForce(Vector3.up * playerGravity);

        if (punchCooldown > 0.0f) punchCooldown -= Time.fixedDeltaTime;
    }

    private void MovePlayer()
    {
        if ((Mathf.Abs(playerDirection.x) > 0.5f || Mathf.Abs(playerDirection.y) > 0.5f) && !moveDisabled)
        {
            playerAnimator.SetBool("Running", true);
            playerController.Move(playerDirection);
        }
        else
        {
            playerAnimator.SetBool("Running", false);
        }
    }

    public void StartPunch()
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Punch")) { return; }

        playerAnimator.SetTrigger("Punch");
    }

    public void StartRaiseChunk()
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Summon")) { return; }

        if (playerController.TryConfirmChunk())
        {
            playerAnimator.SetTrigger("Summon");
        }
    }

    public void AEPunch()
    {
        
        AttemptPunch();
    }

    public void AERaiseChunk()
    {
        playerController.RaiseChunk();
    }

    void AttemptPunch()
    {
        if (punchCooldown <= 0.0f)
        {
            playerController.Punch();
            punchCooldown = punchCooldownMax;
        }
    }

    public void AEEnableMovement()
    {
        moveDisabled = false;
    }

    public void AEDisableMovement()
    {
        moveDisabled = true;
    }

    public void SetControls(bool _active)
    {
        if (_active)
        {
            controls.Player.Enable();
        }
        else
        {
            controls.Player.Disable();
        }
    }
}
