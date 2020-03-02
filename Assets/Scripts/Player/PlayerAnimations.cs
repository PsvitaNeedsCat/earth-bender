using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Player playerScript;
    public PlayerHealth playerHealth;

    public void AEPunch()
    {
        playerScript.AEPunch();
    }

    public void AERaiseChunk()
    {
        playerScript.AERaiseChunk();
    }

    public void AEStartInvincibility()
    {
        playerHealth.AEStartInvincibility();
    }

    public void AEStopInvincibility()
    {
        playerHealth.AEStopInvincibility();
    }

    public void AEEnableMovement()
    {
        playerScript.AEEnableMovement();
    }

    public void AEDisableMovement()
    {
        playerScript.AEDisableMovement();
    }
}
