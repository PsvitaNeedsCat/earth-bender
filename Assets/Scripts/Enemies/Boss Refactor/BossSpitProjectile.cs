using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpitProjectile : MonoBehaviour
{
    [HideInInspector] public GridTile aimedTile;
    [HideInInspector] public BossSpitUpAttack spitUpAttack;
    [HideInInspector] public Rigidbody rigidBody;
    public GameObject hurtboxPrefab;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        spitUpAttack.ProjectileDestroyed(aimedTile);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hurtBox = Instantiate(hurtboxPrefab, transform.position, transform.rotation, null);
        Destroy(hurtBox, 0.1f);
        Destroy(this.gameObject);
    }
}
