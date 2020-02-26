using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpitUpAttack : BossBehaviour
{
    public override void StartBehaviour()
    {
        Debug.Log("Started spit up attack behaviour - will run for 3 seconds");
        StartCoroutine(CompleteAfterSeconds(3.0f));
    }

    public override void Reset()
    {
        base.Reset();

    }
}
