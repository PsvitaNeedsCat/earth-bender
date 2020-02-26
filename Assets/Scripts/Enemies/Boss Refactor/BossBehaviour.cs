using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBehaviour : MonoBehaviour
{
    [HideInInspector] public bool isComplete = false;

    public abstract void StartBehaviour();

    public virtual void Reset()
    {
        isComplete = false;
    }

    protected IEnumerator CompleteAfterSeconds(float afterSeconds)
    {
        yield return new WaitForSeconds(afterSeconds);

        isComplete = true;
    }

}
