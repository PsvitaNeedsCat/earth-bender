using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossHealth : MonoBehaviour
{
    public int health = 3;
    public Animator bossAnimator;
    public Transform bossMeshTransform;
    public GameObject waterCrystal;

    private Boss bossScript;

    private void Awake()
    {
        bossScript = GetComponent<Boss>();
    }

    public int Health
    {
        get { return health; }
        set
        {
            health = value;

            if (health <= 0)
            {
                Death();
            }

        }
    }

    private void Death()
    {
        bossAnimator.SetTrigger("Dead");
    }

    public void Damage(int amount)
    {
        Health -= amount;
        bossScript.tookDamage = true;
        AudioManager.Instance.PlaySoundVaried("ToadDamaged");

        StartCoroutine(FreezeFor(0.05f));
    }

    private IEnumerator FreezeFor(float forSeconds)
    {
        // bossAnimator.speed = 0.0f;
        Time.timeScale = 0.0f;

        yield return new WaitForSecondsRealtime(forSeconds);

        // bossAnimator.speed = 1.0f;
        Time.timeScale = 1.0f;
    }

    private void OnDeath()
    {
        waterCrystal.SetActive(true);
        waterCrystal.transform.parent = null;
    }

    public void AEOnDeath()
    {
        OnDeath();
    }
}
