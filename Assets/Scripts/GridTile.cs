using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public enum GroundType
{
    dirt,
    rock
}

public class GridTile : MonoBehaviour
{
    public GroundType type = GroundType.dirt;
    public GameObject chunkPrefab;
       
    private static float tileSize = 10.0f;
    private Chunk chunk;

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
        if (chunk) { return; }

        chunk = Instantiate(chunkPrefab, transform.position, transform.rotation, null).GetComponent<Chunk>();
        chunk.RaiseChunk();
        chunk.owningTile = this;
    }

    public void RemoveChunk()
    {
        chunk = null;
    }
}
