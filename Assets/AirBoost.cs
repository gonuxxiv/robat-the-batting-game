using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBoost : MonoBehaviour
{
    public Rigidbody2D ball;
    Movement movement;
    public ParticleSystem particleEffect;
    // Start is called before the first frame update
    void Start() {
        movement = ball.GetComponent<Movement>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if(ball.transform.position.x > (transform.position.x - 1.37) && ball.transform.position.x < (transform.position.x + 1.373)){
            if (ball.transform.position.y > (transform.position.y - 2.296) && ball.transform.position.y < (transform.position.y + 2.47)){
                ball.velocity = new Vector2 (ball.velocity.x + 10, 8);
                particleEffect.Play();
                SoundManagerScript.PlaySound("batteryCharged");
                movement.addHop();
                SoundManagerScript.PlaySound("chargingSound");   
                // if(!canAdd){}
                
            }
        }
    }
}
