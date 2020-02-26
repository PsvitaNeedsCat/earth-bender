using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : BossBehaviour
{
    public float idleDuration = 1.0f;

    public override void StartBehaviour()
    {
        Debug.Log("Started idle behaviour - will run for " + idleDuration + " seconds");
        StartCoroutine(CompleteAfterSeconds(idleDuration));
    }

    public override void Reset()
    {
        base.Reset();

    }
}
