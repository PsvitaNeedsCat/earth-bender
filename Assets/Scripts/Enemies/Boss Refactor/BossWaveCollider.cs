using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWaveCollider : MonoBehaviour
{
    public int damage = 1;
    public BossSwampAttack swampAttack;
    public float sphereCastRadius = 3.0f;
    public Vector3 waveDirection = new Vector3(-1.0f, 0.0f, 0.0f);
    public LayerMask waveBlockingLayers;
    public float sphereCastDistance = 100.0f;
    public bool damagedPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth)
        {
            // Check if player is guarded by a block
            //if (!damagedPlayer && !CheckForChunk(playerHealth))
            //{
            //    playerHealth.Damage(damage);
            //    damagedPlayer = true;
            //}

            playerHealth.Damage(damage);
            this.gameObject.SetActive(false);
            return;
        }

        Chunk chunk = other.gameObject.GetComponent<Chunk>();

        if (chunk)
        {
            this.gameObject.SetActive(false);
        }
    }

    private bool CheckForChunk(PlayerHealth health)
    {
        GameObject player = health.gameObject;

        // Check towards positive X
        RaycastHit hitInfo;
        bool result = Physics.SphereCast(player.transform.position, sphereCastRadius, -waveDirection, out hitInfo, sphereCastDistance, waveBlockingLayers);

        return result;
    }
}
