using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;

    private Animator playerAnimator;
    private bool isInvincible = false;

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

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Death()
    {
        playerAnimator.SetBool("Dead", true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Damage(int amount)
    {
        if (isInvincible) { return; }
        Health -= amount;
        playerAnimator.SetTrigger("Hurt");
    }

    public void AEStartInvincibility()
    {
        isInvincible = true;
    }

    public void AEStopInvincibility()
    {
        isInvincible = false;
    }
}
