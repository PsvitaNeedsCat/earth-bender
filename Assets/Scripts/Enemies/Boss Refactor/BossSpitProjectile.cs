using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpitProjectile : MonoBehaviour
{
    [HideInInspector] public bool isFragment = false;
    [HideInInspector] public bool rockEaten = false;
    [HideInInspector] public GridTile aimedTile;
    [HideInInspector] public BossSpitUpAttack spitUpAttack;
    [HideInInspector] public Rigidbody rigidBody;
    public GameObject hurtboxPrefab;

    private static Vector3[] fragmentDirections = { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        if (isFragment) { return; }
        spitUpAttack.ProjectileDestroyed(aimedTile);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hurtBox = Instantiate(hurtboxPrefab, transform.position, transform.rotation, null);

        if (rockEaten && !isFragment) { Split(); }

        Destroy(hurtBox, 0.1f);
        Destroy(this.gameObject);
    }

    private void Split()
    {
        for (int i = 0; i < fragmentDirections.Length; i++)
        {
            BossSpitProjectile fragment = Instantiate(this.gameObject, transform.position + fragmentDirections[i] * 10.0f + Vector3.up * 10.0f,
                transform.rotation, null).GetComponent<BossSpitProjectile>();
            fragment.isFragment = true;
        }
    }
}
