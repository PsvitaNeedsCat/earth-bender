using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour
{
    private int health = 3;
    public Animator playerAnimator;
    public Color hurtColour;
    [SerializeField] float flashTime;
    public SkinnedMeshRenderer playerRenderer;

    TextMeshProUGUI healthText;
    private bool isInvincible = false;
    public Material playerMaterial;

    private void Awake()
    {
        healthText = GameObject.Find("PlayerHP").GetComponent<TextMeshProUGUI>();

        Health = 3;

        playerMaterial = playerRenderer.material;
        playerMaterial = new Material(playerMaterial);
        playerRenderer.material = playerMaterial;
    }

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
        playerAnimator.SetTrigger("Dead");

        // Fade to black
        GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("FadeOut");

        // Load scene again
        GameObject.FindObjectOfType<SceneController>().ReloadCurrentScene();

        Health = 3;
    }

    private void Hurt()
    {
        Sequence seq = DOTween.Sequence();

        AudioManager.Instance.PlaySoundVaried("hurt");

        isInvincible = true;
        seq.Append(playerMaterial.DOColor(hurtColour, flashTime * 0.5f));
        
        seq.Append(playerMaterial.DOColor(Color.white, flashTime * 0.5f)).OnComplete(() => isInvincible = false);
    }

    public void Damage(int amount)
    {
        if (isInvincible) { return; }
        Health -= amount;
        Hurt();
    }

    //public void AEStartInvincibility()
    //{
    //    isInvincible = true;
    //}

    //public void AEStopInvincibility()
    //{
    //    isInvincible = false;
    //}
}
