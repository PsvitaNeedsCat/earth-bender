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
    private Chunk spawningChunk;
    private void Awake()
    {

    }

    private void OnDrawGizmosSelected()
    {
        if (type == GroundType.dirt) { Gizmos.color = Color.cyan; }
        else { Gizmos.color = Color.grey; }

        Gizmos.DrawWireCube(transform.position, new Vector3(tileSize, tileSize, tileSize));
    }

    public void StartRaiseChunk()
    {
        if (spawningChunk) { return; }

        if (!spawningChunk)
        {
            spawningChunk = Instantiate(chunkPrefab, transform.position, transform.rotation, null).GetComponent<Chunk>();
            spawningChunk.owner = this;
        }

        spawningChunk.StartRaise();
    }

    public void StopRaiseChunk()
    {
        Debug.Assert(spawningChunk);

        spawningChunk.StopRaise();
    }

    public void RemoveChunk()
    {
        spawningChunk = null;
    }
}
