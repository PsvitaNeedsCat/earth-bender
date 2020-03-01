using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Public
    public float drag = 2.0f;
    public float punchCooldownMax = 1.0f;

    // Private
    InputMaster controls;
    PlayerController playerController;
    Vector2 playerDirection = new Vector2(0.0f, 0.0f);
    Rigidbody m_rigidBody;
    float punchCooldown = 0.0f;
    private Animator playerAnimator;
    
    private void Awake()
    {
        // Init stuff
        controls = new InputMaster();
        controls.Player.Enable();
        m_rigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

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

        if (punchCooldown > 0.0f) punchCooldown -= Time.fixedDeltaTime;
    }

    private void MovePlayer()
    {
        if (Mathf.Abs(playerDirection.x) > 0.5f || Mathf.Abs(playerDirection.y) > 0.5f)
        {
            playerController.Move(playerDirection);
        }
    }

    public void StartPunch()
    {
        playerAnimator.SetTrigger("Punch");
    }

    public void StartRaiseChunk()
    {
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
}
