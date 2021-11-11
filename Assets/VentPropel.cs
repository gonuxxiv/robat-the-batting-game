using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentPropel : MonoBehaviour
{
    public Rigidbody2D ball;
    private double ventWidth = 2.94;
    private double ventHeight = 0.9;
    private int ventCoordinateX;
    private int ventCoordinateY;
    public ParticleSystem particleEffect;
    private float waftLoc = 0;
    private bool canWaft = true;
    // Start is called before the first frame update

    private void waftCheck(){
        if (ball.transform.position.x > (waftLoc + 2.94)){
            canWaft = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        waftCheck();

        if(ball.transform.position.x > (transform.position.x - 1.47) && ball.transform.position.x < (transform.position.x + 1.47)){
            if (ball.transform.position.y > (transform.position.y - 0.45) && ball.transform.position.y < (transform.position.y + 2.5))
            {
                if (canWaft) {
                    SoundManagerScript.PlaySound("ventair");
                    particleEffect.Play();
                    ball.velocity = new Vector2 (ball.velocity.x, (ball.velocity.y + 15f));
                    waftLoc = ball.transform.position.x;
                    canWaft = false;
                }
            }
        }
    }
}
