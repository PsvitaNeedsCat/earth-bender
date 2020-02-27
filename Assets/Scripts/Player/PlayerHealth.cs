using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Damage(int amount)
    {
        Health -= amount;
    }
}
