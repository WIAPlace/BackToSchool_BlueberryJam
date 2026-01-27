using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

// Camera trigger switch
// Created: 1/25 Weston T
// Purpose: when player enters the trigger switch the camera to this one.
// Edit: Add Enables for Ghosts

public class CameraTriggerSwitch : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Camera That Will Focus On This Room")]
    private CinemachineVirtualCamera roomCam;

    [SerializeField]
    [Tooltip("whatever the player's layer is.")]
    private LayerMask playerLayer;

    [SerializeField]
    [Tooltip("Holds the Ghosts in the Room")]
    private GameObject[] Ghosts;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if((playerLayer.value & (1 << other.gameObject.layer)) != 0)
        { // Only trigger if the player moves into this room
            //Debug.Log("Entered;" + roomCam);
            roomCam.Priority = 15; // Higher priority so this will be the used camera.
            foreach(GameObject roomGhost in Ghosts)
            { // when you enter the room set the ghosts to active
                if(roomGhost != null){ // if it still exists
                    roomGhost.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if((playerLayer.value & (1 << other.gameObject.layer)) != 0)
        { // Only trigger if the player moves into this room
            //Debug.Log("Exited;"+ roomCam);
            roomCam.Priority = 5; // Lower the priority so the next room will be highest priority
            foreach(GameObject roomGhost in Ghosts)
            { // when you enter the room set the ghosts to false
                if(roomGhost != null){ // if it still exists
                    roomGhost.SetActive(false);
                }
            }
        }
    }
}
