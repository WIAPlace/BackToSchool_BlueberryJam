using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FaceTwoardsMove
// Created: 1/24 Weston T
// Purpose: Will rotate a collider twoards where the player is moving

public class FaceTwoardsMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Refrence the parent of this so that we can force their direction twoards it move Direction")]
    private Rigidbody2D rb;
    private Vector2 lastDirection = Vector2.zero;

    // There is a fair bit of debuging left in here, all commented out. I have done this in testing for how to constrain the way the object is facing.


    // Update is called once per frame
    void Update()
    {
        Vector2 direction = rb.velocity; // The direction is twoards where the rigid body is moving.

        if (direction != Vector2.zero && direction != lastDirection) // if the object is moving and not the same as last time
        { // Ive included the second part so we arnt doing this update every frame needlessly.
            float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg; // calculate the angle in radians then degrees
            //Debug.Log(angle); // Testing to see what this will output. 
            // Result from test: the output is similar to a degree circle where right is 0 and it rotates around until the left direction/180 degrees where it begins to go backwards negativly.
            // Thus up is 90 and down is -90. This will be usefull in adding constraints by forcing it into these ranges.
            
            //Debug.Log(angle/90); // The purpose of this test is to see the outputs as single numbers, instead of degrees.

            float roundedAngle = Mathf.RoundToInt(angle/90); // force the angle into a single number that is closes to one of the 4 angles.
            //Debug.Log(roundedAngle); // checking what it output
            roundedAngle *= 90; // puts it back to 90 degrees after rounded to cardinal direction so that it works for direction.
            
            // Apply rotation twoards the direction moving's closest cardinal direction.
            Quaternion targetRotation = Quaternion.AngleAxis(roundedAngle, Vector3.forward); 
            transform.rotation = targetRotation;

            transform.Rotate(Vector3.forward * 90, Space.World); // Forcibly rotates it 90 degrees so that the forward works with where everything else is suposed to be set up.

            lastDirection = direction;
        }

        //Debug.Log(rb.velocity); // Testing to check which direction the object is moving 
        // x = -6 : left = 180 
        // x = +6 : right = 0
        // y = -6 : down = -90
        // y = +6 : up = 90
        // 4.24 = multiple directions
    }
}
