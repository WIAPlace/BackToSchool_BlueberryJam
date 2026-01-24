using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

// Attack
// Created: 1/24 Weston T
// Purpose: Will spawn an attack collider that will sweep like a sword and apply contact to ghosts.

public class Attack : MonoBehaviour
{
    [Header("Refrences")]

    [SerializeField] 
    [Tooltip("This will be the Input Reader Script, for ease of use when making interactions between the input reader and the scripts")]
    private InputReader input; // Input reader refrence so that controls work

    [SerializeField] 
    [Tooltip("The prefab for the attack collider")]
    private GameObject attackCollider; // The Prefab used for the attack collider

    [SerializeField] 
    [Tooltip("Child of Player the helps signify which way is forward relative to movement")]
    private Transform forwardDir;

    [Header("Variable Values")]

    [SerializeField] 
    [Tooltip("Determines how fast the swing animation will be")]
    private float swingSpeed;

    [SerializeField] 
    [Range(0f, 90f)] // if this goes above 90 degrees it will rotate the wrong way so it must stay within this range
    [Tooltip("Determines how wide the swing will swipe")]
    private float swingSize; // Swing size will determine width of the swing along the way the player is facing. 

    private bool attacking = false; // Bool to check if there is an instance of the attack collider active.
    private Quaternion targetRotation; // Target rotation for the swing to be for
    private  GameObject attackInstance; // Instance of the attack collider object.

    private void Start()
    {
        input.AttackEvent += HandleAttack; // activates the ability to attack via input
    }

    private void SpawnCollider()
    {
        attacking = true; // confirms there is an instance of the attack collider object

        targetRotation = Quaternion.Euler(0f, 0f, swingSize); // Offset for swing size
        targetRotation = targetRotation*forwardDir.rotation; // combined to get final result
        // Target rotation for the swing to be for

        Quaternion startingRotation =  Quaternion.Euler(0f, 0f, -swingSize);

        attackInstance = Instantiate(attackCollider,transform.position, forwardDir.rotation*startingRotation); 
        // Creates an instance of the attack collider prefab at the position of player with the starting rotation being based on the players rotation and the swing size;
    }

    void Update()
    {
        if (attacking) // if there is an instance of the attack colider active
        {   
            attackInstance.transform.rotation = Quaternion.RotateTowards(attackInstance.transform.rotation, targetRotation, swingSpeed * Time.deltaTime);
            // rotate twoards the target rotation.

            attackInstance.transform.position = transform.position; // Keeps the collider with the player.
            
            if (Quaternion.Angle(attackInstance.transform.rotation, targetRotation) < 0.1f && attackInstance != null) 
            // if the Rotation has reached its end point destroy it. && !=null as a catch just to make sure we dont try to delete something that isnt there.
            {   
                Destroy(attackInstance);
                attacking = false;
            }
        }
    }

    private void HandleAttack()
    {
        if (!attacking) // if there is no instance of the attacking object
        {
            SpawnCollider();
        }
    }



}
