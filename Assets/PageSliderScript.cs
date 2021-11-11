using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSliderScript : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    int currentPage = 1;
    public GameObject SwipeLeftImage;
    public GameObject SwipeRightImage;
    private Vector2 startTouchPosition, endTouchPosition, direction;

    // Update is called once per frame
    void Update()
    {
        SwipeCheck();
    }

    private void SwipeCheck()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            // get touch finger position
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            // get release finger position
            endTouchPosition = Input.GetTouch(0).position;

            // calculate swipe direction
            direction = startTouchPosition - endTouchPosition;

            if (endTouchPosition.x > startTouchPosition.x)
            {
                if(currentPage == 1)
                {
                    Page1.SetActive(false);
                    Page2.SetActive(true);
                    SwipeLeftImage.SetActive(true);
                    currentPage++;
                }
                else if (currentPage == 2)
                {
                    Page2.SetActive(false);
                    Page3.SetActive(true);
                    SwipeRightImage.SetActive(false);
                    currentPage++;
                }

            }
            else if (endTouchPosition.x < startTouchPosition.x)
            {
                if(currentPage == 2)
                {
                    Page1.SetActive(true);
                    Page2.SetActive(false);
                    SwipeLeftImage.SetActive(false);       
                    currentPage--;             
                }
                else if (currentPage == 3)
                {
                    Page3.SetActive(false);
                    Page2.SetActive(true);
                    SwipeRightImage.SetActive(true);
                    currentPage--;
                }
            }
        }
    }
}
