using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrailScript : MonoBehaviour
{
    public Rigidbody2D ball;
    private Color greenStart = new Color(0, 1, (float)0.1179614, 1);
    private Color greenEnd = new Color((float)0.7176551, 1, 0, 1);
    private Color redStart = new Color(1, (float)0.1112901, 0, 1);
    private Color redEnd = new Color(1, (float)0.440684, 0, 1);
    private Color blueStart = new Color(0, (float)0.6912971, 1, 1);
    private Color blueEnd = new Color(0, (float)0.9820707, 1, 1);
    private Color yellowStart = new Color(1, (float)0.9863348, 0, 1);
    private Color yellowEnd = new Color((float)0.9622642, (float)0.9493525, (float)0.7307761, 1);
    public float velocity;
    public ParticleSystem ballTrail;

    // Start is called before the first frame update
    void Start()
    {
        ballTrail = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {   
        velocity = ball.velocity.x;
        var main = ballTrail.main;

        if (velocity > 300)
        {
            main.startColor = yellowStart;
        }
        else if (velocity > 200 && velocity < 300)
        {
            main.startColor = redStart;
        }

        else if (velocity > 100 && velocity < 200)
        {
            main.startColor = greenStart;
        }

        else if (velocity > 50 && velocity < 100)
        {
            main.startColor = blueStart;
        }

        else if (50 > velocity)
        {
            main.startColor = new Color(0, 0, 0, 0);
        }
    }
}
