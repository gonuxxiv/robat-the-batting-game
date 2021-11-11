using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{

    private Vector2 startTouchPosition, endTouchPosition, direction; 
    float touchTimeStart, touchTimeFinish, timeInterval; // calculate swipe time
    private float swingForce = 3f;
    private bool swingAllowed = false;

    private void Update()
    {
        SwipeCheck();
    }

    private void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            // marking time of touch
            touchTimeStart = Time.time;

            // get touch finger position
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            // marking time of release
            touchTimeFinish = Time.time;

            // calculate swipe time interval
            timeInterval = touchTimeFinish - touchTimeStart;

            // get release finger position
            endTouchPosition = Input.GetTouch(0).position;

            // calculate swipe direction
            direction = startTouchPosition - endTouchPosition;

            if (endTouchPosition.x > startTouchPosition.x)
            {
                swingAllowed = true;
            }
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ball")
        {
            Debug.Log(2);
            // col.gameObject.GetComponent<Rigidbody2D>().velocity = (transform.right * 100) + (transform.up * 10);
            if (swingAllowed) 
            {
                col.gameObject.GetComponent<Rigidbody2D> ().AddForce (-direction/timeInterval * swingForce);
                col.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
                swingAllowed = false;
            }
            
        }
        
    }
}
