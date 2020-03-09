using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelGrid : MonoBehaviour
{
    private GridTile[] groundTiles;
    private Player playerScript;

    public GridTile[] GroundTiles
    {
        get { return groundTiles; }
    }

    private void Awake()
    {
        groundTiles = FindObjectsOfType<GridTile>();
        playerScript = FindObjectOfType<Player>();
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

            Vector3 toPlayer = tile.transform.position - playerScript.transform.position;
            toPlayer.y = 0.0f;

            if (toPlayer.magnitude < 7.0f) { continue; }

            if (dist < closestDist)
            {
                closest = tile;
                closestDist = dist;
            }
        }

        return closest;
    }

    public GridTile FindClosestTileAny(Vector3 queryPosition)
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
