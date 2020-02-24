using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    public LevelGrid grid;

    private void OnDrawGizmos()
    {
        // if (!Application.isPlaying) { return; }

        GridTile closest = grid.FindClosestTile(transform.position);

        Gizmos.color = Color.red;
        Gizmos.DrawCube(closest.transform.position, Vector3.one * 11.0f);

    }
}
