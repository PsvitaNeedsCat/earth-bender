using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using Cinemachine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 3;
    public Animator playerAnimator;
    public Color hurtColour;
    [SerializeField] float flashTime;
    public SkinnedMeshRenderer playerRenderer;
    [SerializeField] Sprite shatter1; // One damage taken
    [SerializeField] Sprite shatter2; // Two damage taken

    TextMeshProUGUI healthText;
    private bool isInvincible = false;
    public Material playerMaterial;

    private void Awake()
    {
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
            if (value < health)
            {
                // Screen shake
                GetComponent<CinemachineImpulseSource>().GenerateImpulse();
            }

            health = value;

            UpdateShatter();

            if (health <= 0)
            {
                Death();
            }
        }
    }

    void UpdateShatter()
    {
        Image _shatter = GameObject.Find("Shatter").GetComponent<Image>();

        Color _colour = _shatter.color;

        switch (health)
        {
            case 3:
                {
                    _colour.a = 0.0f;
                    break;
                }
            case 2:
                {
                    _colour.a = 1.0f;
                    _shatter.sprite = shatter1;
                    break;
                }
            case 1:
                {
                    _colour.a = 1.0f;
                    _shatter.sprite = shatter2;
                    break;
                }

            default:
                return;
        }

        _shatter.color = _colour;
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
}
