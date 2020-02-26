using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    // Public
    public Room _room;

    private void OnTriggerEnter(Collider other)
    {
        // Reset room
        _room.ResetRoom();
    }
}
