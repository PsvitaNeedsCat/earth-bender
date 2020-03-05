using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 3;
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
        
    }

    public void Damage(int amount)
    {
        Health -= amount;
        bossScript.tookDamage = true;
        AudioManager.Instance.PlaySoundVaried("ToadDamaged");
    }

}
