using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BossHurtBox : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        Debug.Log(other.gameObject.name);

        if (playerHealth)
        {
            playerHealth.Damage(damage);
        }
    }
}
