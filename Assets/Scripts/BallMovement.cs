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
    AudioSource ballAudioSource;

    void Start()
    {
        ballAudioSource = GetComponent<AudioSource>();
        ballRb = GetComponent<Rigidbody>();
        StartBallMovement();
        lastPosition = transform.position;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        MeasureSpeed();
    }

    void StartBallMovement()
    {
        startDirection = Random.insideUnitCircle.normalized;
        ballRb.velocity = startDirection * ballSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ballAudioSource.Play();
        ballSpeed = ballSpeed * speedIncrement;
        ballRb.velocity = ballRb.velocity.normalized * ballSpeed;
    }

    public float MeasureSpeed()
    {
        speed = Mathf.Lerp(speed, (transform.position - lastPosition).magnitude / Time.deltaTime, 0.7f);
        lastPosition = transform.position;

        return speed;
    }
}
