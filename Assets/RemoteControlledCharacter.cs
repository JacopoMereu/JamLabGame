using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControlledCharacter : MonoBehaviour
{
    Vector3 moveDirection;

    private void Start()
    {
        moveDirection = transform.position;
    }

    public void Move (Vector3 direction)
    {
        //Use the x and z values of the direction vector to move the character
        moveDirection.x += direction.x * Time.deltaTime;
        moveDirection.z += direction.z * Time.deltaTime;
        
        //Move the character
        transform.position = moveDirection;
        
        //Rotate the character to face the direction it is moving
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction); 

    }
}
