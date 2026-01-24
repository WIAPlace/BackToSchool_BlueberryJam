using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Input Reader
// Created: 1/22 Weston T
// Purpose: To Act as a bridge between inputs and functions they apply to in a way that is easy to use. 
// 

[CreateAssetMenu(menuName = "InputReader")]
public class InputReader : ScriptableObject, InputSystem.IGameplayActions, InputSystem.IUIActions
{
    private InputSystem inputSystem;

    private void OnEnable() 
    {// When this is enabled if it doesn't already exist make it
        if(inputSystem == null)
        {
            inputSystem = new InputSystem();

            inputSystem.Gameplay.SetCallbacks(this);
            inputSystem.UI.SetCallbacks(this);

            SetGameplay(); // Set Gameplay On Start of playing the game
        }
    }
    void OnDisable()
    {
        inputSystem.Gameplay.Disable();
        inputSystem.UI.Disable();
    }

    public void SetGameplay() // while in gameplay the UI wont be interacted with
    {
        inputSystem.Gameplay.Enable();
        inputSystem.UI.Disable();
    }
    public void SetUI() // while in UI the Gameplay wont be interacted with
    {
        inputSystem.Gameplay.Disable();
        inputSystem.UI.Enable();
    }

    // Envents to use in scripts that will pass the values of the Event Functions
    public event Action <Vector2> MoveEvent; // Passes a vector 2 for the move event (Vector 2 because it can be multiple directions, like up+right )
    public event Action AttackEvent; // button pressed will activate attack
    
    public event Action PauseEvent; // Pause same Button as resume
    public event Action ResumeEvent; // Resume same Button as pause




    // Event Functions that will pass values to the events in scripts
    // the ? after each event name is to signify to do it if it exists.
    public void OnAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    { // when button (like mouse) is pressed attack will play
       AttackEvent?.Invoke();
    }

    public void OnLook(UnityEngine.InputSystem.InputAction.CallbackContext context)
    { // use mouse/right stick to deside the direction
        // Not Implemented At the Moment
    }

    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    { // Movement based on directional movement. 
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPause(UnityEngine.InputSystem.InputAction.CallbackContext context)
    { // Turn of Gameplay controlls and go to UI controls
        if( context.phase == InputActionPhase.Performed ){
            PauseEvent?.Invoke();
            SetUI();
        }
    }

    public void OnResume(UnityEngine.InputSystem.InputAction.CallbackContext context)
    { // Turn off UI and go back to gamePlay
        if( context.phase == InputActionPhase.Performed ){
            ResumeEvent?.Invoke();
            SetGameplay();
        }
    }
}
