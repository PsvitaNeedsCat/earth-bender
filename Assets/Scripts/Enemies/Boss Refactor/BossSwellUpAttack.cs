using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwellUpAttack : BossBehaviour
{
    public override void StartBehaviour()
    {
        Debug.Log("Started swell up attack behaviour - will run for 5 seconds");
        StartCoroutine(CompleteAfterSeconds(5.0f));
    }

    public override void Reset()
    {
        base.Reset();

    }
}
