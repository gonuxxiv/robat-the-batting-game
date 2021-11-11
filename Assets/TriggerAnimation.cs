using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    Animator anim;
    private Vector2 startTouchPosition, endTouchPosition; 
    public bool swingAllowed = false;
    Movement BallMovementScript;
    public CameraMove cameraMovement;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        SwipeCheck();
    }

    // void FixedUpdate()
    // {
    //     SwingIfAllowed();
    // }

    void SwipeCheck()
    {
        GameObject ballObject = GameObject.Find("Ball");
        Movement BallMovementScript = ballObject.GetComponent<Movement>();


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            // get touch finger position
            startTouchPosition = Input.GetTouch(0).position;

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            // get release finger position
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.x > startTouchPosition.x)
            {
                if (BallMovementScript.pitchedOrNot)
                {
                    swingAllowed = true;
                    anim.SetTrigger("Swing");    
                    cameraMovement.movementTimerStart();        
                }

            }
        }
    }

    // void SwingIfAllowed()
    // {
    //     if (swingAllowed)
    //     {
    //         anim.SetTrigger("Swing");
    //     }
    // }
}
