using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{    
    //Default move value
    private float movementSpeed = 1f;

    private void FixedUpdate()
    {
        //Does not execute the rest of the code if this check is true
        if (GameManager.isGameOn == false)  return;
        //To move the ship
        Movement();
    }


    void Movement()
    {
        //To store the position before the movement
        Vector2 pos = transform.position;
        //To move the ship down
        pos.y -= movementSpeed * Time.fixedDeltaTime;
        //To actually move the ship
        transform.position = pos;
    }
}
