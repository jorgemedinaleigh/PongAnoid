using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float ballSpeed = 20f;
    Vector3 startDirection;
    Rigidbody ballRb;

    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        StartBallMovement();
    }

    void Update()
    {
        ballRb.velocity = ballRb.velocity.normalized * ballSpeed;
    }

    void StartBallMovement()
    {
        startDirection = Random.insideUnitCircle.normalized;
        ballRb.velocity = startDirection * ballSpeed;
    }
}
