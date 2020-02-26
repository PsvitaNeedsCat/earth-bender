using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelGrid : MonoBehaviour
{
    public GridTile[] groundTiles;

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
