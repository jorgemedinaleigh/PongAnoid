using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUPlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 20;
    [SerializeField] float movementRange = 10;

    GameObject ball;
    float numberOfBlocks;

    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    void Update()
    {
        ProcessMovement();
        ProcessDefeat();
    }

    void ProcessMovement()
    {
        float yOffset = ball.transform.localPosition.y * Time.deltaTime * movementSpeed;
        float yPos = transform.localPosition.y - yOffset ;
        float clampedYPos = Mathf.Clamp(yPos, -movementRange, movementRange);

        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }

    float CountBlocks()
    {
        numberOfBlocks = transform.childCount;
        return numberOfBlocks;
    }

    void ProcessDefeat()
    {
        if (CountBlocks() <= 0)
        {
            Destroy(gameObject);
        }
    }
}
