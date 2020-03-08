using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject dialogBox;

    public void ActivateDialogBox()
    {
        dialogBox.SetActive(true);
    }

    public void DeactivateDialogBox()
    {
        dialogBox.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player)
        {
            ActivateDialogBox();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player)
        {
            DeactivateDialogBox();
        }
    }
}
