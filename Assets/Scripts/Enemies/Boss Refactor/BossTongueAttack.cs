﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTongueAttack : BossBehaviour
{
    public Animator tongueAnimator;
    public BossTongueCollider tongueCollider;
    public Boss bossScript;
    public GameObject tongueAimIndicator;

    private bool isRetracting = false;

    public override void StartBehaviour()
    {
        base.StartBehaviour();

        // ExtendTongue();

        playerAnimator.SetTrigger("TongueAttack");
        tongueAimIndicator.SetActive(true);
        
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
            if (tongueAnimator.GetCurrentAnimatorStateInfo(0).IsName("Tongue_Extend") && tongueAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.01f)
            {
                tongueAnimator.SetTrigger("Retract");
            }
        }
    }

    private void Swallow()
    {
        GroundType typeSwallowed = tongueCollider.Swallow();
        Debug.Log("Swallowed: " + typeSwallowed.ToString());

        if (typeSwallowed == GroundType.poison)
        {
            bossScript.atePoison = true;

        }

        if (typeSwallowed == GroundType.dirt)
        {
            bossScript.ateRock = true;
        }

        tongueAnimator.gameObject.SetActive(false);
        tongueAnimator.SetFloat("TongueExtendDirection", 1.0f);
        tongueAimIndicator.SetActive(false);

        if (typeSwallowed != GroundType.none)
        {
            AudioManager.Instance.PlaySoundVaried("gulp");
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

    public void OnRetracted()
    {
        playerAnimator.SetTrigger("TongueAttackFinished");
        Debug.Log("Set tongueattackfinished");
    }

    public void AEExtendTongue()
    {
        ExtendTongue();
    }

    public void AESwallow()
    {
        Swallow();
    }
}
