using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimations : MonoBehaviour
{
    public Boss bossScript;
    public BossSpitUpAttack spitUpAttack;
    public BossSwellUpAttack swellUpAttack;
    public BossSwampAttack swampAttack;
    public BossTongueAttack tongueAttack;

    public void AESpitProjectile()
    {
        spitUpAttack.AESpitProjectile();
    }

    public void AESpittingFinished()
    {
        spitUpAttack.AESpittingFinished();
    }

    public void AELaunchWave()
    {
        swampAttack.LaunchWave();
    }

    public void AEFrogLand()
    {
        swampAttack.AEFrogLand();
    }

    public void AESwampBehaviourComplete()
    {
        swampAttack.AEBehaviourComplete();
    }

    public void AETongueBehaviourComplete()
    {
        tongueAttack.AEBehaviourComplete();
    }

    public void AESpitUpBehaviourComplete()
    {
        spitUpAttack.AEBehaviourComplete();
    }

    public void AESwellUpBehaviourComplete()
    {
        swellUpAttack.AEBehaviourComplete();
    }

    public void AEExtendTongue()
    {
        tongueAttack.AEExtendTongue();
    }

    public void AESwallow()
    {
        tongueAttack.AESwallow();
    }

    public void AEAwake()
    {
        bossScript.AEAwake();
    }
}
