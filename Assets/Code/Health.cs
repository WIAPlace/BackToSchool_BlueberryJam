using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Health
// Created: 1/24 Weston T
// Purpose: class for all health, player and ghose

public class Health : MonoBehaviour
{
    [SerializeField]
    [Tooltip("What layer will damage this entity")] 
    private LayerMask damageLayer; // Damage layer is serializable so that only something of this layer will hurt it

    [SerializeField] private int maxHealth = 3; // max health. keeping this serialized so that it could be changed if we want beefyer or weaker ghosts.
    private int currentHealth; // current health

    [SerializeField]
    [Tooltip("how many seconds in between being hit until you can take damage again.")]
    private float hitDelay; // will be multiplied by 50 so that it works in fixed update

    private float currentDelayTime;
    

    void Start()
    {
        currentHealth = maxHealth;

    }
    private void FixedUpdate()
    {
        if (currentDelayTime > 0)
        {
            currentDelayTime-=1;
        }
    }


    void OnCollisionEnter2D(Collision2D collision) // on entering a collision
    {
        //Debug.Log("Hit: "+ gameObject);
        if((damageLayer.value & (1 << collision.gameObject.layer)) != 0 && currentDelayTime <= 0)
        {
            //Debug.Log("Hit Layer");
            currentDelayTime = hitDelay*50;
            currentHealth -=1; // take one damage when hit by layer

            if (currentHealth <= 0)
            {
                // possibly play animation for being hit before destroying self

                Destroy(gameObject); // destroys self. if we do want the animation we can put in a delay by doing , after game object and a float so Destroy(gameObject,2f)
            }
        }
    }
    
}
