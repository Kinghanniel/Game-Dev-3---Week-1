using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator shipAnimatorVariable;
    PlayerMovement playerMovementScriptReference;

    // Start is called before the first frame update
    void Start()
    {
        shipAnimatorVariable = GetComponent<Animator>();
        playerMovementScriptReference = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the parameter based on the boolean in the player movement script
        shipAnimatorVariable.SetBool("amIMoving", playerMovementScriptReference.isShipMoving);
    }
}
