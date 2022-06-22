using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 20;
    [SerializeField] float movementRange = 10;

    float vertical;

    void Update()
    {
        ProcessMovement();
    }

    void ProcessMovement()
    {
        if(Input.GetKey(KeyCode.O))
        {
            vertical = 1;
        }
        else if(Input.GetKey(KeyCode.L))
        {
            vertical = -1;
        }        

        float yOffset = vertical * Time.deltaTime * movementSpeed;
        float yPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(yPos, -movementRange, movementRange);

        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }
}