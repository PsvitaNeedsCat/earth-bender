using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTargeter : MonoBehaviour
{
    private LevelGrid levelGrid;
    public float maxRange = 5.0f; // center of blocks needs to be within range
    public GameObject targetIndicator;

    private GridTile closest;

    private void OnEnable()
    {
        if (!levelGrid)
        {
            levelGrid = FindObjectOfType<LevelGrid>();
            Debug.Assert(levelGrid, "TileTargeter failed to find a level grid");
        }
    }

    private void Update()
    {
        closest = levelGrid.FindClosestTile(transform.position);

        Vector3 diff = closest.transform.position - transform.position;
        diff.y = 0.0f;

        // If the closest tile is within range
        if (diff.magnitude < maxRange && !closest.IsOccupied())
        {
            targetIndicator.SetActive(true);
            targetIndicator.transform.position = closest.transform.position;
            targetIndicator.transform.rotation = closest.transform.rotation;
        }
        else
        {
            targetIndicator.SetActive(false);
            closest = null;
        }
    }

    public GridTile GetClosest()
    {
        return closest;
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying) { return; }
        Gizmos.DrawWireSphere(transform.position, maxRange);
    }
}
