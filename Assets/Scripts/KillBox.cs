﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Chunk chunk = other.GetComponent<Chunk>();

        if (chunk)
        {
            chunk.DestroyQuiet();
        }

        MossHurlerProjectile mossHurlerProjectile = other.GetComponent<MossHurlerProjectile>();

        if (mossHurlerProjectile)
        {
            mossHurlerProjectile.DestroyProjectile();
        }
    }
}
