using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public enum GroundType
{
    none,
    dirt,
    rock,
    poison
}

public class GridTile : MonoBehaviour
{
    public GroundType type = GroundType.dirt;
    public GameObject chunkPrefab;
    public LayerMask raycastLayerMask;

    private static float tileSize = 10.0f;

    private void Awake()
    {

    }

    private void OnDrawGizmosSelected()
    {
        if (type == GroundType.dirt) { Gizmos.color = Color.cyan; }
        else { Gizmos.color = Color.grey; }

        Gizmos.DrawWireCube(transform.position, new Vector3(tileSize, tileSize, tileSize));
    }

    public void TryRaiseChunk()
    {
        // Don't try to raise a chunk if there's already one here
        if (IsOccupied()) { return; }

        Chunk chunk = Instantiate(chunkPrefab, transform.position, transform.rotation, null).GetComponent<Chunk>();
        chunk.RaiseChunk();
    }

    public bool IsOccupied()
    {
        return Physics.Raycast(transform.position, Vector3.up, tileSize, raycastLayerMask);
    }
}
