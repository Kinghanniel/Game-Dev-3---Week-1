using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroller : MonoBehaviour
{
    public Transform topPosition;
    public Rigidbody2D[] tilesRb;

    public float movementSpeed;
    public Vector2 outOfBound;


    private void FixedUpdate()
    {
        //This method is on the fixed update because
        //it deals with Physics
        TilesMovement();
    }



    private void TilesMovement()
    {
        //Cycles through all the rigidbodies of the tiles
        for (int i = 0; i < tilesRb.Length; i++)
        {
            //Sets the velocity of each tile's rigidbody tp be the  same as speed
            //It also multiplies it to Time.fixedDeltaTime to make it frame independent
            tilesRb[i].velocity = new Vector2(0, movementSpeed) * Time.fixedDeltaTime;

            //Checks the currently active game object
            CheckPosition(tilesRb[i].gameObject);
        }
    }

    public void CheckPosition(GameObject objectToCheck)
    {
        //Checks if the y position of the object to check is smaller or equal to the 
        //out of boud value
        if (objectToCheck.transform.position.y <= outOfBound.y)
        {
            //If it is, it moves it to the top
            MoveToTheTop(objectToCheck);
        }
    }

    public void MoveToTheTop(GameObject objectToMove)
    {
        //Move the gameobject that went out of bounds back on top
        objectToMove.transform.position = topPosition.position;
    }
}
