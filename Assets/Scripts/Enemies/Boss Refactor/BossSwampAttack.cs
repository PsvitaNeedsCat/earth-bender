using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossSwampAttack : BossBehaviour
{
    public float underwaterTime = 5.0f;
    public float chargeUpTime = 3.0f;
    public Animator waveAnimator;
    public GameObject waveObject;
    private BossWaveCollider waveCollider;
    private CinemachineImpulseSource cameraShake;

    // Move a box collider over the whole level
    // If the player is hit, raycast to check if they were guarded by a block
    private void Awake()
    {
        waveCollider = waveObject.GetComponent<BossWaveCollider>();
        cameraShake = GetComponent<CinemachineImpulseSource>();
    }

    public override void StartBehaviour()
    {
        base.StartBehaviour();

        // Debug.Log("Started swamp attack behaviour");

        playerAnimator.SetTrigger("SwampAttackInitiate");
        StartCoroutine(JumpBackOn());
    }

    private IEnumerator JumpBackOn()
    {
        yield return new WaitForSeconds(underwaterTime);

        playerAnimator.SetTrigger("SwampAttackFinish");
        WaveComplete();
    }

    public void LaunchWave()
    {
        waveObject.SetActive(true);
        waveCollider.damagedPlayer = false;
        waveAnimator.SetTrigger("Surge");
    }

    public void WaveComplete()
    {
        waveObject.SetActive(false);
    }

    public override void Reset()
    {
        base.Reset();
    }

    public void AELaunchWave()
    {
        LaunchWave();
    }

    public void AEFrogLand()
    {
        cameraShake.GenerateImpulse();
    }
}
