using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpitUpAttack : BossBehaviour
{
    public GameObject projectilePrefab;
    public GameObject aimIndicatorPrefab;
    public int numProjectiles = 3;
    public float projectileFireDelay = 0.5f;
    public float waitAfterFiring = 5.0f;
    public float dropHeight = 100.0f;
    public Transform projectileSpawnSocket;

    // private List<BossSpitProjectile> projectiles = new List<BossSpitProjectile>();
    private Dictionary<int, GridTile> levelTiles = new Dictionary<int, GridTile>();
    private Boss bossScript;
    private LevelGrid grid;

    private static Vector3[] fragmentDirections = { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };

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

    private IEnumerator SpittingFinished()
    {
        yield return new WaitForSeconds(1.0f);

        if (bossScript.ateRock)
        {
            bossScript.ateRock = false;
        }
    }

    private IEnumerator SpitProjectile()
    {
        AudioManager.Instance.PlaySoundVaried("ToadSpit");

        // Create projectile
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnSocket.position, Quaternion.identity, null);
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

        List<GameObject> aimIndicators = new List<GameObject>();

        aimIndicators.Add(Instantiate(aimIndicatorPrefab, aimTile.transform.position, Quaternion.identity, null));
        
        if (bossScript.ateRock)
        {
            for (int i = 0; i < 4; i++)
            {
                aimIndicators.Add(Instantiate(aimIndicatorPrefab, aimTile.transform.position + (fragmentDirections[i] * 10.0f), Quaternion.identity, null));
            }
        }

        proj.AddAimIndicators(aimIndicators);
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
        StartCoroutine(SpitProjectile());
    }

    public void AESpittingFinished()
    {
        StartCoroutine(SpittingFinished());
    }
}
