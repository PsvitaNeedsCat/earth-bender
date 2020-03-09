using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

public class BossAnimations : MonoBehaviour
{
    public Boss bossScript;
    public BossSpitUpAttack spitUpAttack;
    public BossSwellUpAttack swellUpAttack;
    public BossSwampAttack swampAttack;
    public BossTongueAttack tongueAttack;
    public BossHealth bossHealth;
    public GameObject healthCanvas;

    private CinemachineImpulseSource cameraShake;

    private void Awake()
    {
        cameraShake = GetComponent<CinemachineImpulseSource>();
    }

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
        AudioManager.Instance.PlaySoundVaried("ToadLand");
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
        AudioManager.Instance.PlaySoundVaried("ToadTongue");
    }

    public void AESwallow()
    {
        tongueAttack.AESwallow();
    }

    public void AEAwake()
    {
        bossScript.AEAwake();
    }

    public void AEPlayRoarSound()
    {
        AudioManager.Instance.PlaySoundVaried("ToadRoar");

        StartCoroutine(CameraShakeAfter(0.1f));
    }

    private IEnumerator CameraShakeAfter(float afterSeconds)
    {
        yield return new WaitForSeconds(afterSeconds);

        cameraShake.GenerateImpulse();
    }

    public void AEOnDeath()
    {
        bossHealth.AEOnDeath();
    }

    public void AEActivateHealthBar()
    {
        healthCanvas.SetActive(true);
    }
}
