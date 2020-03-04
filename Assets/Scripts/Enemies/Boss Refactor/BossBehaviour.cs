using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBehaviour : MonoBehaviour
{
    [HideInInspector] public bool isComplete = false;
    [HideInInspector] public bool isActive = false;
    public Animator playerAnimator;

    public virtual void StartBehaviour()
    {
        isActive = true;
    }

    public virtual void Reset()
    {
        isComplete = false;
        isActive = false;
    }

    protected IEnumerator CompleteAfterSeconds(float afterSeconds)
    {
        yield return new WaitForSeconds(afterSeconds);

        isComplete = true;
    }

    public void AEBehaviourComplete()
    {
        isComplete = true;
    }
}
