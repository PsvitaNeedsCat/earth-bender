using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class WaterCrystal : MonoBehaviour
{
    public BossAnimations bossAnimations;
    public GameObject victoryCanvas;
    public Image fadeToWhite;
    private bool pickedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player && !pickedUp)
        {
            pickedUp = true;

            transform.DOMove(transform.position + Vector3.up * 10.0f , 1.0f).SetEase(Ease.OutSine);
            transform.DORotate(new Vector3(0.0f, 720.0f, 0.0f), 1.0f, RotateMode.LocalAxisAdd).SetEase(Ease.OutSine);
            victoryCanvas.SetActive(true);
            fadeToWhite.DOColor(Color.white, 4.0f).OnComplete(() => SceneManager.LoadScene("Menu")).SetEase(Ease.OutSine);

        }
    }

    public void AETingSound()
    {
        bossAnimations.AETingSound();
    }

    public void AnimationFinished()
    {
        Destroy(GetComponent<Animator>());
    }
}
