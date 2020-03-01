using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private int health = 3;
    [SerializeField] TextMeshProUGUI healthText;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;

            if (healthText) { healthText.text = "Health: " + health; }

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
