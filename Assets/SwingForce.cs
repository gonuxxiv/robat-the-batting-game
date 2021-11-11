using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingForce : MonoBehaviour
{
    Animator anim;
    private Vector2 startTouchPosition, endTouchPosition, direction; 
    float touchTimeStart, touchTimeFinish, timeInterval; // calculate swipe time
    private float swingForce = 100f;
    private bool swingAllowed = false;

    private void Update()
    {
        SwipeCheck();
    }

    private void FixedUpdate()
    {
        SwingIfAllowed();
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

    private void SwingIfAllowed()
    {
        if (swingAllowed)
        {
            GetComponent<Rigidbody2D> ().AddForce ((-direction/timeInterval * swingForce) * 100);
            swingAllowed = false;
        }
    }
}
