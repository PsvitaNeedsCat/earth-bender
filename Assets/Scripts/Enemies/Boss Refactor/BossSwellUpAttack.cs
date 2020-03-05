using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossSwellUpAttack : BossBehaviour
{
    public float swellUpOver = 1.0f;
    public float staySwelledUpFor = 5.0f;
    public SkinnedMeshRenderer bossRenderer;
    public Material swollenMaterial;
    public Transform meshTransform;

    private Boss bossScript;
    private float swelledTimer = 0.0f;
    private float startingScale;
    private Material normalMaterial;

    private void Awake()
    {
        bossScript = GetComponent<Boss>();
        startingScale = meshTransform.localScale.x;
        normalMaterial = bossRenderer.material;
    }
    public override void StartBehaviour()
    {
        base.StartBehaviour();

        // Debug.Log("Started swell up attack behaviour");

        StartCoroutine(Swell());
    }

    private IEnumerator Swell()
    {
        SwellUp();

        while (!bossScript.tookDamage && swelledTimer < staySwelledUpFor)
        {
            swelledTimer += Time.deltaTime;
            yield return null;
        }

        SwellDown();

        // StartCoroutine(CompleteAfterSeconds(swellUpOver));
    }

    private void SwellUp()
    {
        playerAnimator.SetTrigger("SwellUp");
        bossScript.invincible = false;
        meshTransform.DOKill();
        meshTransform.DOScale(startingScale * 1.1f, swellUpOver).SetEase(Ease.OutElastic);
        bossRenderer.material = swollenMaterial;
    }

    private void SwellDown()
    {
        playerAnimator.SetTrigger("SwellDown");

        bossScript.tookDamage = false;
        bossScript.invincible = true;

        meshTransform.DOKill();
        meshTransform.DOScale(startingScale, swellUpOver).SetEase(Ease.OutElastic);
        bossRenderer.material = normalMaterial;
    }

    public override void Reset()
    {
        base.Reset();
        swelledTimer = 0.0f;
    }
}
