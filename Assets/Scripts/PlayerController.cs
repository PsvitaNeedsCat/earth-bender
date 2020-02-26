using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public
    public float moveSpeed = 1.0f;
    public GameObject hurtBoxPrefab;
    public float punchBoxMoveBy;
    public GameObject tileTargeter;
    public int maxChunks = 3;

    // Private
    private Rigidbody m_rigidBody;
    private List<Chunk> activeChunks;

    // Temp
    public LevelGrid grid;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();

        activeChunks = new List<Chunk>();
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
        Instantiate(hurtBoxPrefab, spawnPos, transform.rotation);
    }

    public void ActivateTileTargeter()
    {
        // Debug.Log("Activated tile targeter");
        tileTargeter.SetActive(true);
    }

    public void DeactivateTileTargeter()
    {
        // Debug.Log("Deactivated tile targeter");
        tileTargeter.SetActive(false);
    }

    public void TryRaiseChunk()
    {
        // Debug.Log("Trying raise chunk");
        GridTile tile = grid.FindClosestTile(transform.position + transform.forward * 10.0f);
        tile.TryRaiseChunk();
    }

    public void AddChunk(Chunk newChunk)
    {
        // If at chunk limit, destroy oldest chunk
        if (activeChunks.Count >= maxChunks && activeChunks.Count > 0)
        {
            RemoveChunk(activeChunks[0]);
        }

        // Create new chunk
        activeChunks.Add(newChunk);
    }

    public void RemoveChunk(Chunk removeChunk)
    {
        for (int i = 0; i < activeChunks.Count; i++)
        {
            if (activeChunks[i].GetInstanceID() == removeChunk.GetInstanceID())
            {
                Destroy(activeChunks[i].gameObject);
                activeChunks.RemoveAt(i);
                return;
            }
        }

        Debug.Assert(true, "Couldn't find chunk to be removed");
    }
}
