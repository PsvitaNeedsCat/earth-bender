using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogBoss : MonoBehaviour
{
    public Image healthBarFilled;
    public Transform[] tongueAttackLocations;
    public GameObject tongueObject;
    public Animator tongueAnimator;

    private float currentHealth = 100.0f;
    private float maxHealth;

    private void Awake()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        maxHealth = currentHealth;
        Debug.Assert(tongueAttackLocations.Length > 0, "No tongue attack locations provided");

        StartCoroutine(TongueAttackLoop());
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            healthBarFilled.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0.0f, 1.0f);

            if (currentHealth < 0.0f)
            {
                Death();
            }
        }
    }

    public void Damage(float amount)
    {
        CurrentHealth -= amount;
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator TongueAttackLoop()
    {
        StartTongueAttack();

        yield return new WaitForSeconds(4.0f);

        StartCoroutine(TongueAttackLoop());
    }

    public void StartTongueAttack()
    {
        Transform attackTransform = GetAttackLocation();
        tongueObject.SetActive(true);
        tongueAnimator.GetComponent<Animator>().SetFloat("TongueExtendDirection", 1.0f);
        tongueAnimator.GetComponent<Animator>().SetTrigger("Extend");
        tongueObject.transform.position = attackTransform.position;
        tongueObject.transform.rotation = attackTransform.rotation;
        StartCoroutine(FinishTongueAttack());
    }

    private IEnumerator FinishTongueAttack()
    {
        yield return new WaitForSeconds(2.0f);
        tongueObject.SetActive(false);
    }

    private Transform GetAttackLocation()
    {
        int attackLocationNum = Random.Range(0, tongueAttackLocations.Length);

        return tongueAttackLocations[attackLocationNum];
    }
}
