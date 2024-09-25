using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField]Vector2 movement;
    Rigidbody2D shipRigidBody;
    public bool isShipMoving = false;

    private void Start()
    {
        //Gets the component and stores it into the variable
        shipRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //If the game is off, it will not continue the code
        if (GameManager.isGameOn == false)
        {
            return;
        }


        //The next two lines will find the input values and will store them into out movement variable
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //If we are moving the bool will be true (!= means NOT EQUAL)
        if (movement.x != 0 || movement.y != 0)
        {
            isShipMoving = true;
        }
        else
        {
            isShipMoving = false;
        }
    }
    //To make sure it the camera does not jitter when the player moves
    private void FixedUpdate()
    {
        //The MovePosition() methos will move the rigidbody of the ship
        shipRigidBody.MovePosition(shipRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
