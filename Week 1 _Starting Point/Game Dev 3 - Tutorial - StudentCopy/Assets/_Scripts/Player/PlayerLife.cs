using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] int playerHp = 3;


    //To dead damege to the player or kill them
    // if the hp are at 0 or less
    public void DealDamage(int damageValue)
    {
        if ((playerHp - damageValue) <= 0)
        {
            //By making this bool false the game will stop
            GameManager.isGameOn = false;
            //Destroys the ship
            Destroy(gameObject);
        }
        else
        {
            //Deals the damage
            playerHp -= damageValue;
        }
    }
}
