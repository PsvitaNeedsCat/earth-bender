using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwampAttack : BossBehaviour
{
    public override void StartBehaviour()
    {
        Debug.Log("Started swamp attack behaviour - will run for 4 seconds");
        StartCoroutine(CompleteAfterSeconds(4.0f));
    }

    public override void Reset()
    {
        base.Reset();

    }
}
