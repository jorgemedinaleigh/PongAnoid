using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float ballSpeed = 20f;
    [SerializeField] float speedIncrement = 1.01f;
    float speed;
    Vector3 startDirection;
    Vector3 lastPosition;
    Rigidbody ballRb;

    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        StartBallMovement();
        lastPosition = transform.position;
    }

    void Update()
    {
        ballRb.velocity = ballRb.velocity.normalized * ballSpeed;
    }

    private void FixedUpdate()
    {
        speed = Mathf.Lerp(speed, (transform.position - lastPosition).magnitude / Time.deltaTime, 0.7f);
        lastPosition = transform.position;
        Debug.Log("Speed: " + speed);
    }

    void StartBallMovement()
    {
        startDirection = Random.insideUnitCircle.normalized;
        ballRb.velocity = startDirection * ballSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        ballSpeed = ballSpeed * speedIncrement;
        ballRb.velocity = ballRb.velocity.normalized * ballSpeed;
    }
}
