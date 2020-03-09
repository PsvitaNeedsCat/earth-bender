using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTongueCollider : MonoBehaviour
{
    public int damage = 1;
    public BossTongueAttack tongueAttack;
    private Chunk attachedChunk = null;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        
        if (playerHealth)
        {
            playerHealth.Damage(damage);
            tongueAttack.RetractTongue();
            
            return;
        }

        if (!attachedChunk)
        {
            Chunk chunk = other.GetComponent<Chunk>();

            if (chunk)
            {
                // Pick up & eat chunk
                AudioManager.Instance.PlaySoundVaried("stuck");

                chunk.Detach();

                chunk.GetComponent<Rigidbody>().velocity = Vector3.zero;
                chunk.transform.parent = this.transform;
                chunk.GetComponent<Collider>().isTrigger = true;

                attachedChunk = chunk;
                tongueAttack.RetractTongue();
                return;
            }
        }
    }

    public void OnRetracted()
    {
        tongueAttack.OnRetracted();
    }

    public GroundType Swallow()
    {
        if (!attachedChunk) { return GroundType.none; }

        GroundType type = attachedChunk.type;

        attachedChunk.DestroyQuiet();

        return type;
    }
}
