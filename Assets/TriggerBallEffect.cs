using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBallEffect : MonoBehaviour
{
    public GameObject TrailEffect;
    public Rigidbody2D ball;
    public float ballVelocity;
    private ParticleSystem ballTrail;
    private Color greenStart = new Color(0, 1, (float)0.1179614, 1);
    private Color greenEnd = new Color((float)0.7176551, 1, 0, 1);
    private Color redStart = new Color(1, (float)0.1112901, 0, 1);
    private Color redEnd = new Color(1, (float)0.440684, 0, 1);
    private Color blueStart = new Color(0, (float)0.6912971, 1, 1);
    private Color blueEnd = new Color(0, (float)0.9820707, 1, 1);
    private Color yellowStart = new Color(1, (float)0.9863348, 0, 1);
    private Color yellowEnd = new Color((float)0.9622642, (float)0.9493525, (float)0.7307761, 1);
    // Update is called once per frame
    void Start(){
        ballTrail = TrailEffect.GetComponent<ParticleSystem>();
    }

    public void getVelocity(){
        if (ball.velocity.y < 0){
            ballVelocity = (ball.velocity.x + (-1 * (ball.velocity.y)));
        }

        else {
            ballVelocity = (ball.velocity.x + ball.velocity.y);
        }
    }
    void Update()
    {
        getVelocity();
        // TrailEffect.setActive(true);
        TrailEffect.transform.position = new Vector3(transform.position.x - 0.75f, transform.position.y - 0.15f, transform.position.z);

        if (ballVelocity > 300)
        {
            ballTrail.startColor = yellowStart;
        }
        else if (ballVelocity > 200 && ballVelocity < 300)
        {
            ballTrail.startColor = redStart;
        }

        else if (ballVelocity > 100 && ballVelocity < 200)
        {
            ballTrail.startColor = greenStart;
        }

        else if (ballVelocity > 50 && ballVelocity < 100)
        {
            ballTrail.startColor = blueStart;
        }

        else if (50 > ballVelocity)
        {
            
            ballTrail.startColor = new Color(255, 0, 0, 0);
        }
        
    }
}
