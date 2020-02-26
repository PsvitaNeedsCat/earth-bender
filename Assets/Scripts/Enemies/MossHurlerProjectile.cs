using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossHurlerProjectile : MonoBehaviour
{
    [HideInInspector] public int damage;

    private void OnTriggerEnter(Collider other)
    {
        Chunk chunk = other.gameObject.GetComponent<Chunk>();

        if (chunk)
        {
            DestroyProjectile();
            return;
        }

        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth)
        {
            playerHealth.Damage(damage);
            DestroyProjectile();
            return;
        }
    }

    public void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
