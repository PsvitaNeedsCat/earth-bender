using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxScript : MonoBehaviour
{
    public int framesBeforeDestroy;
    public float hitForce = 1.0f;
    private int framesSkipped = 0;

    private void Update()
    {
        if (framesSkipped < framesBeforeDestroy) framesSkipped += 1;
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Chunk chunk = other.GetComponent<Chunk>();
        
        if (chunk)
        {
            Vector3 forward = transform.forward;
            forward.y = 0.0f;

            Vector3 cardinal = GetCardinalDir(forward);
            chunk.Hit(cardinal * hitForce);
        }
    }

    private Vector3 GetCardinalDir(Vector3 dir)
    {
        Vector3 cardinalDir;

        if (Mathf.Abs(dir.z) > Mathf.Abs(dir.x))
        {
            if (dir.z > 0.0f)
            {
                cardinalDir = Vector3.forward;
            }
            else
            {
                cardinalDir = Vector3.back;
            }
        }
        else
        {
            if (dir.x > 0.0f)
            {
                cardinalDir = Vector3.right;
            }
            else
            {
                cardinalDir = Vector3.left;
            }
        }

        return cardinalDir;
    }
}
