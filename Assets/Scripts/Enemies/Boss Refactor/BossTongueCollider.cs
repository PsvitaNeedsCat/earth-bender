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
                chunk.Detach();
                FixedJoint newJoint = gameObject.AddComponent<FixedJoint>();
                newJoint.connectedBody = chunk.GetComponent<Rigidbody>();
                attachedChunk = chunk;
                tongueAttack.RetractTongue();
                return;
            }
        }
    }

    public GroundType Swallow()
    {
        if (!attachedChunk) { return GroundType.none; }

        GroundType type = attachedChunk.type;

        Destroy(attachedChunk);

        return type;
    }
}
