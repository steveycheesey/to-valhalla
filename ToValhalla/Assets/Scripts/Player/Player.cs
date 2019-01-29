//  To Valhalla!
//  >Version 0.1<

//  Player Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float playerMaxHealth;
    float playerCurrentHealth;

    [SerializeField]
    float playerMoveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRoll();
    }

    void HandleMovement()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");


    }

    void HandleRoll()
    {

    }

    #region healthfunctions
    //use this function to damage the player, as opposed to doing it directly
    public void TakeDamage(float dmg)
    {
        //reduces current health by the damage amount taken
        playerCurrentHealth -= dmg;

        //ensures player health can not fall below 0
        if(playerCurrentHealth <= 0)
        {
            playerCurrentHealth = 0.0f;
        }

        //debug message to display health and damage taken
        Debug.Log("Player took " + dmg + " damage! Current health: " + playerCurrentHealth);
    }

    //use this function to heal the player, as opposed to doing it directly
    public void HealPlayer(float heal)
    {
        playerCurrentHealth += heal;
        if (playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
        Debug.Log("Player healed by " + heal + ". Current health: " + playerCurrentHealth);
    }
    #endregion
}
