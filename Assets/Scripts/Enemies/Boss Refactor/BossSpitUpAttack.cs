using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpitUpAttack : BossBehaviour
{
    public GameObject projectilePrefab;
    public int numProjectiles = 3;
    public float projectileFireDelay = 0.5f;
    public float waitAfterFiring = 5.0f;
    public float dropHeight = 100.0f;

    // private List<BossSpitProjectile> projectiles = new List<BossSpitProjectile>();
    private Dictionary<int, GridTile> levelTiles = new Dictionary<int, GridTile>();
    private Boss bossScript;
    private LevelGrid grid;

    private void Awake()
    {
        bossScript = GetComponent<Boss>();
    }

    private void Start()
    {
        grid = FindObjectOfType<LevelGrid>();

        GridTile[] gridTiles = grid.GroundTiles;

        for (int i = 0; i < gridTiles.Length; i++)
        {
            levelTiles.Add(gridTiles[i].GetInstanceID(), gridTiles[i]);
        }
    }

    public override void StartBehaviour()
    {
        base.StartBehaviour();

        // Debug.Log("Started spit up attack behaviour");
        // StartCoroutine(SpitProjectiles());
        playerAnimator.SetTrigger("Spit");
    }

    private void SpittingFinished()
    {
        if (bossScript.ateRock)
        {
            bossScript.ateRock = false;
        }

        // isComplete = true;
    }

    private IEnumerator SpitProjectile()
    {
        // Create projectile
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position + Vector3.up * 30.0f, transform.rotation, null);
        BossSpitProjectile proj = newProjectile.GetComponent<BossSpitProjectile>();
        proj.spitUpAttack = this;

        // Find a tile for it to aim for 
        GridTile aimTile = GetRandomFreeTile();
        proj.aimedTile = aimTile;
        ProjectileCreated(aimTile);

        proj.rigidBody.AddForce(Vector3.up * 2.0f, ForceMode.Impulse);

        if (bossScript.ateRock) { proj.rockEaten = true; }

        yield return new WaitForSeconds(0.5f);

        // When projectile is off screen, move it above the tile it will land on
        proj.rigidBody.velocity = Vector3.zero;
        proj.transform.position = proj.aimedTile.transform.position + Vector3.up * dropHeight;
    }

    public override void Reset()
    {
        base.Reset();
    }

    private GridTile GetRandomFreeTile()
    {
        List<int> keyList = new List<int>(levelTiles.Keys);
        int randomIndex = Random.Range(0, keyList.Count);
        int randomKey = keyList[randomIndex];
        return levelTiles[randomKey];
    }

    public void ProjectileCreated(GridTile newTile)
    {
        levelTiles.Remove(newTile.GetInstanceID());
    }

    public void ProjectileDestroyed(GridTile tile)
    {
        levelTiles.Add(tile.GetInstanceID(), tile);
    }

    public void AESpitProjectile()
    {
        SpitProjectile();
    }

    public void AESpittingFinished()
    {
        SpittingFinished();
    }
}
