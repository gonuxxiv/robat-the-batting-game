using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowDistance : MonoBehaviour
{
    CalculateDistance distanceTravelled;
    // TextMeshPro myText = GetComponent<TextMeshPro>();
    TriggerAnimation animationTriggeredCheck;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject ballObject = GameObject.Find("Ball");
        CalculateDistance distanceTravelled = ballObject.GetComponent<CalculateDistance>();

        GameObject animation = GameObject.Find("batter_spritesheet_0");
        TriggerAnimation animationTriggeredCheck = animation.GetComponent<TriggerAnimation>();
        
        if (!distanceTravelled.ballStopped)
        {
            GetComponent<TextMeshProUGUI>().text = Mathf.Floor(distanceTravelled.distanceTravelled) + " m";            
        }
    }
}
