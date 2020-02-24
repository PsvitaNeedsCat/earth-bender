using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public
    public float moveSpeed = 1.0f;

    // Private
    Rigidbody m_rigidBody;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 _direction)
    {
        // Get yaw
        float yaw = Camera.main.transform.rotation.eulerAngles.y;

        // Convert to 3D
        Vector3 moveDir = new Vector3(_direction.x, 0.0f, _direction.y);

        // Rotate direction vector by yaw
        moveDir = Quaternion.Euler(new Vector3(0.0f, yaw, 0.0f)) * moveDir;

        // Set look direction
        this.transform.forward = moveDir;
        // Add force
        m_rigidBody.AddForce(moveDir * 10.0f * moveSpeed, ForceMode.Impulse);
    }
}
