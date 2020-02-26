using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTargeter : MonoBehaviour
{
    private LevelGrid levelGrid;
    public float checkRange = 5.0f; // center of blocks needs to be within range
    public GameObject targetIndicator;

    private void Awake()
    {
        levelGrid = FindObjectOfType<LevelGrid>();

        Debug.Assert(levelGrid, "TileTargeter failed to find a level grid");
    }

    private void Update()
    {
        GridTile closest = levelGrid.FindClosestTile(transform.position);

        // If the closest tile is within range
        if ((closest.transform.position - transform.position).magnitude < checkRange)
        {
            targetIndicator.SetActive(true);
            targetIndicator.transform.position = closest.transform.position;
            targetIndicator.transform.rotation = closest.transform.rotation;
        }
        else
        {
            targetIndicator.SetActive(false);
        }
    }



    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying) { return; }
        Gizmos.DrawWireSphere(transform.position, checkRange);
    }
}
