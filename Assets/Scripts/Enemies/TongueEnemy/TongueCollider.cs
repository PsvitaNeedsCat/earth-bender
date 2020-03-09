using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class TongueCollider : MonoBehaviour
{
    public int damage = 1;
    public TongueEnemy tongueEnemy;
    private Chunk attachedChunk = null;
    public Transform tweenTransform;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth)
        {
            playerHealth.Damage(damage);
            Retract();

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

                Retract();
                return;
            }
        }
    }

    public void Extend()
    {
        AudioManager.Instance.PlaySoundVaried("ToadTongue");

        tongueEnemy.isExtending = true;

        // Tween to tweenPosition
        transform.DOKill(false);
        transform.DOMove(tweenTransform.position, 1.0f).OnComplete(() => Retract());

        Debug.Log("Extending");
    }

    void Retract()
    {
        tongueEnemy.isExtending = false;
        tongueEnemy.isRetracting = true;

        // Tween back to TongueEnemy
        transform.DOKill(false);
        transform.DOMove(tongueEnemy.transform.position, 1.0f).OnComplete(() => tongueEnemy.Swallow());

        Debug.Log("Retracting");
    }

    public GroundType Swallow()
    {
        if (!attachedChunk) { return GroundType.none; }

        GroundType type = attachedChunk.type;

        attachedChunk.DestroyQuiet();

        return type;
    }
}
