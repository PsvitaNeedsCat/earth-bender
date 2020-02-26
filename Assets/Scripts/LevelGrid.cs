using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelGrid : MonoBehaviour
{
    public GridTile[] groundTiles;

    [HideInInspector] public int numRows;
    [HideInInspector] public int numCols;

    private void Awake()
    {
        int numTiles = groundTiles.Length;

        Debug.Assert(numTiles > 0, "No tiles in the tile grid");
        // Debug.Assert(groundTiles.Length > 0);

        float sqrtResult = Mathf.Sqrt(numTiles);
        Debug.Assert((sqrtResult % 1) == 0, "Tile grid doesn't have a square number of tiles");

        numRows = (int)sqrtResult;
        numCols = (int)sqrtResult;
    }

    public GridTile FindClosestTile(Vector3 queryPosition)
    {
        Debug.Assert(groundTiles.Length > 0);

        float closestDist = 10000.0f;
        GridTile closest = null;

        for (int i = 0; i < groundTiles.Length; i++)
        {
            GridTile tile = groundTiles[i];

            float dist = (tile.transform.position - queryPosition).magnitude;

            if (dist < closestDist)
            {
                closest = tile;
                closestDist = dist;
            }
        }

        return closest;
    }
}
