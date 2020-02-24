using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public
    public float moveSpeed = 1.0f;
    public GameObject hurtBoxRef;
    public float punchBoxMoveBy;

    // Private
    Rigidbody m_rigidBody;

    // Temp
    public LevelGrid grid;
    private GridTile currentTile;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Move forward in a given direction
    /// </summary>
    /// <param name="_direction"> Direction </param>
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
        m_rigidBody.AddForce(moveDir.normalized * 10.0f * moveSpeed, ForceMode.Impulse);
    }

    /// <summary>
    /// Creates hurt box directly in front of player for a short period of time
    /// </summary>
    public void Punch()
    {
        Vector3 spawnPos = transform.position;
        // Normalise transform.forward
        // Multiply by moveBy value
        // Add to spawnPos
        spawnPos += (transform.forward.normalized * punchBoxMoveBy);

        spawnPos.y += GetComponent<Collider>().bounds.size.y * 0.5f;

        // Spawn in
        Instantiate(hurtBoxRef, spawnPos, transform.rotation);
    }

    public void StartCharging()
    {
        currentTile = grid.FindClosestTile(transform.position + transform.forward * 10.0f);

        currentTile.StartRaiseChunk();
    }

    public void StopCharging()
    {
        Debug.Assert(currentTile);

        currentTile.StopRaiseChunk();
    }
}
