using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossSwampAttack : BossBehaviour
{
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

        Debug.Log("Started swamp attack behaviour");

        StartCoroutine(WaveChargeUp());
    }

    private IEnumerator WaveChargeUp()
    {
        yield return new WaitForSeconds(chargeUpTime);

        LaunchWave();
    }

    public void LaunchWave()
    {
        waveObject.SetActive(true);
        waveCollider.damagedPlayer = false;
        waveAnimator.SetTrigger("Surge");
    }

    public void WaveComplete()
    {
        cameraShake.GenerateImpulse();
        waveObject.SetActive(false);
        isComplete = true;
    }

    public override void Reset()
    {
        base.Reset();

    }
}
