using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossSwellUpAttack : BossBehaviour
{
    public float swellUpOver = 1.0f;
    public float staySwelledUpFor = 5.0f;
    private Boss bossScript;
    private float swelledTimer = 0.0f;
    private float startingScale;

    private void Awake()
    {
        bossScript = GetComponent<Boss>();
        startingScale = transform.localScale.x;
    }
    public override void StartBehaviour()
    {
        base.StartBehaviour();

        Debug.Log("Started swell up attack behaviour");
        
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

        StartCoroutine(CompleteAfterSeconds(swellUpOver));
    }

    private void SwellUp()
    {
        bossScript.invincible = false;
        transform.DOKill();
        transform.DOScale(startingScale * 1.5f, swellUpOver).SetEase(Ease.OutElastic);
    }

    private void SwellDown()
    {
        bossScript.tookDamage = false;
        bossScript.invincible = true;
        
        transform.DOKill();
        transform.DOScale(startingScale, swellUpOver).SetEase(Ease.OutElastic);
    }

    public override void Reset()
    {
        base.Reset();
        swelledTimer = 0.0f;
    }
}
