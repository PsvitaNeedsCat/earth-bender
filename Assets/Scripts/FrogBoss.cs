using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogBoss : MonoBehaviour
{
    public Image healthBarFilled;

    private float currentHealth = 100.0f;
    private float maxHealth;

    private void Awake()
    {
        maxHealth = currentHealth;
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
}
