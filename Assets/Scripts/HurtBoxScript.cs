using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxScript : MonoBehaviour
{
    public int framesBeforeDestroy;
    private int framesSkipped = 0;

    private void Update()
    {
        if (framesSkipped < framesBeforeDestroy) framesSkipped += 1;
        else
        {
            Destroy(this.gameObject);
        }
    }
}
