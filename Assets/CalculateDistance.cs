using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    public float distanceTravelled;
    public float lastPosition;
    TriggerAnimation animationTriggeredCheck;
    float lastDistanceTravelled;
    public bool ballStopped = false;
    public Rigidbody2D rb;

    void Start()
    {
        lastPosition = transform.position.x;
    }

    void Update()
    {
        distanceTravelled += transform.position.x - lastPosition;

        lastPosition = transform.position.x;
        lastDistanceTravelled = distanceTravelled;
        

        if (rb.velocity.magnitude < 0.1)
        {
            Debug.Log("Ball stopped");
            ballStopped = true;
        }
        else if (transform.position.x > -6.0051699 && transform.position.x < 7.45 && transform.position.y == 2.75)
        {
            ballStopped = true;
            Time.timeScale = 0.25f;
            rb.velocity = new Vector3(0, 0, 0);
        }
        else if (transform.position.x < -8.7293204)
        {
            ballStopped = true;
            Time.timeScale = 0.25f;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
