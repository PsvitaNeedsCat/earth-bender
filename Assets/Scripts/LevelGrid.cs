using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelGrid : MonoBehaviour
{
    private GridTile[] groundTiles;

    public GridTile[] GroundTiles
    {
        get { return groundTiles; }
    }

    private void Awake()
    {
        groundTiles = FindObjectsOfType<GridTile>();
    }

    public GridTile FindClosestTile(Vector3 queryPosition)
    {
        Debug.Assert(groundTiles.Length > 0);

        float closestDist = 10000.0f;
        GridTile closest = null;

        for (int i = 0; i < groundTiles.Length; i++)
        {
            GridTile tile = groundTiles[i];
            if (tile.type == GroundType.none) { continue; }

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
