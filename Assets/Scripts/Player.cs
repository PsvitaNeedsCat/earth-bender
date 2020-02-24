using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Public
    public float drag = 2.0f;

    // Private
    InputMaster controls;
    PlayerController playerController;
    Vector2 playerDirection = new Vector2(0.0f, 0.0f);
    Rigidbody m_rigidBody;

    private void Awake()
    {
        // Init stuff
        controls = new InputMaster();
        controls.Player.Enable();
        m_rigidBody = GetComponent<Rigidbody>();

        playerController = GetComponent<PlayerController>();

        // Controls
        controls.Player.HorizontalMovement.performed += ctx => playerDirection.x = ctx.ReadValue<float>();
        controls.Player.VerticalMovement.performed += ctx => playerDirection.y = ctx.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        if (playerDirection != new Vector2(0.0f, 0.0f)) playerController.Move(playerDirection);

        // Manual Drag (X and Z)
        Vector3 vel = m_rigidBody.velocity;
        vel.x *= (0.98f / drag);
        vel.z *= (0.98f / drag);
        m_rigidBody.velocity = vel;
    }
}
