using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;



public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D ball;
    public Camera Camera;
    public double initialPosition = 7.45;
    public bool movement;
    
    
    void Start()
    {
        movement = false;
    //    initialWidth = (transform.position.x * 5.6);
        
    }
    
    public void movementTimerStart()
    {
        StartCoroutine(timing());
    }

    IEnumerator timing()
    {
        yield return new WaitForSeconds((float)(0.6));
        movement = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(movement)
        {
            if (ball.position.x > initialPosition && ball.position.y > 9.75)
            {
                transform.position = new Vector3(ball.position.x, ball.position.y, transform.position.z);
                Camera.orthographicSize = 10;
            }
            else if (ball.position.x > 7.45 && ball.position.y < 9.82)
            {
                transform.position = new Vector3(ball.position.x, 7.85f, transform.position.z);
            }
        }
    }
}
