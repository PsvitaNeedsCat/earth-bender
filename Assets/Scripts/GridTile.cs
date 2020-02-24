using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    dirt,
    rock
}

public class GridTile : MonoBehaviour
{
    public TileType type = TileType.dirt;
    [HideInInspector] public float tileSize = 1.0f;

    private void OnDrawGizmosSelected()
    {
        if (type == TileType.dirt) { Gizmos.color = Color.green; }
        else { Gizmos.color = Color.grey; }

        Gizmos.DrawWireCube(transform.position, new Vector3(tileSize, tileSize, tileSize));
    }
}
