using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
        vertical = Input.GetAxisRaw("Vertical");

        float yOffset = vertical * Time.deltaTime * movementSpeed;
        float yPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(yPos, -movementRange, movementRange);

        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }
}
