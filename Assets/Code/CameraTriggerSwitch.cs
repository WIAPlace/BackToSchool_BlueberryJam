using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

// Camera trigger switch
// Created: 1/25 Weston T
// Purpose: when player enters the trigger switch the camera to this one.

public class CameraTriggerSwitch : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Camera That Will Focus On This Room")]
    private CinemachineVirtualCamera roomCam;

    [SerializeField]
    [Tooltip("whatever the player's layer is.")]
    private LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Entered;");
        if((playerLayer.value & (1 << other.gameObject.layer)) != 0)
        { // Only trigger if the player moves into this room
            roomCam.Priority = 15; // Higher priority so this will be the used camera.
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Exited;");
        if((playerLayer.value & (1 << other.gameObject.layer)) != 0)
        { // Only trigger if the player moves into this room
            roomCam.Priority = 5; // Lower the priority so the next room will be highest priority
        }
    }
}
