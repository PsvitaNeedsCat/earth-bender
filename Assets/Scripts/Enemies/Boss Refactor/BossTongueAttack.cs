using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTongueAttack : BossBehaviour
{
    public Animator tongueAnimator;
    public BossTongueCollider tongueCollider;
    public Boss bossScript;
    private bool isRetracting = false;

    public override void StartBehaviour()
    {
        base.StartBehaviour();

        ExtendTongue();

        Debug.Log("Started tongue attack behaviour");

        // StartCoroutine(CompleteAfterSeconds(3.0f));
    }
    public override void Reset()
    {
        base.Reset();
        isRetracting = false;
    }

    private void Update()
    {
        if (!isActive) { return; }

        if (isRetracting)
        {
            if (tongueAnimator.GetCurrentAnimatorStateInfo(0).IsName("BossTongueExtend") && tongueAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.01f)
            {
                tongueAnimator.SetTrigger("Retract");
            }
        }

        if (tongueAnimator.GetCurrentAnimatorStateInfo(0).IsName("BossTongueIdle"))
        {
            Debug.Log("TongueAttack finished");
            tongueAnimator.gameObject.SetActive(false);
            tongueAnimator.SetFloat("TongueExtendDirection", 1.0f);

            GroundType typeSwallowed = tongueCollider.Swallow();
            if (typeSwallowed == GroundType.poison)
            {
                bossScript.atePoison = true;
            }

            isComplete = true;
        }
    }

    

    private void ExtendTongue()
    {
        Debug.Log("ExtendingTongue");
        tongueAnimator.gameObject.SetActive(true);
        tongueAnimator.SetTrigger("Extend");
    }

    public void RetractTongue()
    {
        if (tongueAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
        {
            Debug.Log("Tried to retract tongue after halfway, not reversing animation");
            return;
        }

        tongueAnimator.SetFloat("TongueExtendDirection", -1.0f);
        isRetracting = true;
    }
}
