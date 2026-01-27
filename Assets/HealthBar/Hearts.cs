using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Created by: Sam Saeger
// edited 1/26 by weston tollet - added connection between is and the players health script.
public class Hearts : MonoBehaviour
{
    // current health will always be the player's heath.
    public int health => playerHealth.GetHealth();
    public int maxHealth = 3;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    [SerializeField]
    [Tooltip("Player's Health thing")]
    private Health playerHealth; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health) 
            {
                hearts[i].sprite = fullHeart;
                //Debug.Log(i);
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;

            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        
    }
}
