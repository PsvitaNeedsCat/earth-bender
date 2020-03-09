using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossHurlerProjectile : MonoBehaviour
{
    [HideInInspector] public int damage;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth)
        {
            playerHealth.Damage(damage);
        }

        DestroyProjectile();
    }

    public void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
