using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballParticleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    public Rigidbody2D body;
    private Rigidbody2D ballVelocity;

    void Start(){
        ballVelocity = ball.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (ball.transform.position.x, ball.transform.position.y - (float)0.4, ball.transform.position.z);
        body.velocity = ballVelocity.velocity;
    }
}
