using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

// State Checker
// Created: 1/24 Weston T
// Purpose: Checks what state the game should be in, that being playing, win, or loose.
// This Should be placed on an external object from the player since the player will be destroyed when this should activate.

public class StateChecker : MonoBehaviour
{
    [SerializeField] 
    [Tooltip("Player game object will go here")]
    private GameObject playerState;

    [SerializeField] 
    [Tooltip("Loose Scene")]
    private string looseSceneName;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == null)
        { // if player is destroyed the scene will change to the loose scene.
            SceneManager.LoadScene(looseSceneName); 
        }

    }
}
