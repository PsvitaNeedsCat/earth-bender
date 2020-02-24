using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum TileType
{
    dirt,
    rock
}

public class GridTile : MonoBehaviour
{
    public TileType type = TileType.dirt;
    
    private static float tileSize = 10.0f;

    private void OnDrawGizmosSelected()
    {
        if (type == TileType.dirt) { Gizmos.color = Color.cyan; }
        else { Gizmos.color = Color.grey; }

        Gizmos.DrawWireCube(transform.position, new Vector3(tileSize, tileSize, tileSize));
    }
}
