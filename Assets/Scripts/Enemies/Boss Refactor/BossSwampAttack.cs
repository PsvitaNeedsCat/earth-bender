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

    private float startingX;

    private float[] possibleXPositions;

    // Move a box collider over the whole level
    // If the player is hit, raycast to check if they were guarded by a block
    private void Awake()
    {
        waveCollider = waveObject.GetComponent<BossWaveCollider>();
        cameraShake = GetComponent<CinemachineImpulseSource>();

        startingX = transform.parent.position.x;
        
        float[] positions = { startingX - 10.0f, startingX, startingX + 10.0f};
        possibleXPositions = positions;
    }

    public override void StartBehaviour()
    {
        base.StartBehaviour();

        playerAnimator.SetTrigger("SwampAttackInitiate");
        StartCoroutine(JumpBackOn());
    }

    private IEnumerator JumpBackOn()
    {
        yield return new WaitForSeconds(underwaterTime/2.0f);

        float newXPos = possibleXPositions[Random.Range(0, 3)];
        Vector3 oldPos = transform.parent.position;
        oldPos.x = newXPos;
        transform.parent.position = oldPos;

        yield return new WaitForSeconds(underwaterTime/2.0f);

        playerAnimator.SetTrigger("SwampAttackFinish");
    }

    public void LaunchWave()
    {
        waveObject.SetActive(true);
        waveObject.GetComponent<BossWaveObject>().OnWaveStart();
        waveAnimator.SetTrigger("Surge");
        AudioManager.Instance.PlaySoundVaried("SwampWave");
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
