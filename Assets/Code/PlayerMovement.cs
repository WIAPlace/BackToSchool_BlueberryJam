using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Movement
// Created: 1/22 Weston T
// Purpose: Player's ability to move.


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; // Rigid Body of the Player Object
    [SerializeField] private InputReader input; // Input reader refrence so that controls work
    [SerializeField] private float speed; // Speed of the player

    private Vector2 moveDir; // Direction of movement

    private void Start()
    {   // Activating the input actions.
        input.MoveEvent+=HandleMove;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Gets the RB attached to player for use in code
    }
    private void FixedUpdate()
    {
        Move(); // Function for movement.
    }

    private void Move() // Movement script
    {
        if (moveDir == Vector2.zero)
        { // If the player isnt moving dont bother running through this script.
            rb.velocity = Vector2.zero;
            return;
        }
        rb.velocity = moveDir*(speed*Time.deltaTime);
    }

    private void HandleMove(Vector2 dir)
    {
        moveDir = dir*10; // Direction is equal to move inputed.
    }

}
