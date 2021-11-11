using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 50f;
    public float friction = 20f;
    public Rigidbody2D rb;
    public float height = 5f;
    public bool swipedOrNot = false;
    private float swingForceLvl5 = 2.5f;
    private float swingForceLvl4 = 2f;
    private float swingForceLvl3 = 1.5f;
    private float swingForceLvl2 = 1f;
    private float swingForceLvl1 = 0.75f;
    private Vector2 startTouchPosition, endTouchPosition, direction;
    float touchTimeStart, touchTimeFinish, timeInterval; // calculate swipe time
    TriggerAnimation animationTriggeredCheck;
    CalculateDistance CalculateDistance;
    public Button PitchBallBtn;
    public bool pitchedOrNot = false;
    public GameObject PerfectHitEffect;
    public int hopCount;
    public bool ballHit = false;
    public Image batteryIcon;
    public Sprite batteryEmpty;
    public Sprite batteryOne;
    public Sprite batteryTwo;
    public Sprite batteryThree;
    private bool canAdd;
    private float addLoc = 0;
    public PauseMenu PauseMenu;
    public ParticleSystem hopParticles;
    private ParticleSystem hopInstance;
    
    void Start()
    {
        Button PitchBall = PitchBallBtn.GetComponent<Button>();
        PitchBall.onClick.AddListener(PitchButtonOnClick);
    }

    void PitchButtonOnClick()
    {
        Time.timeScale = 1f;
        if (rb.velocity.magnitude == 0)
        {
            SoundManagerScript.PlaySound("pitchingMachine");
            GameMusicScript.PlayGameBGM();
            movementStart();
        }
    }

    public void movementStart()
    {
        StartCoroutine(timing());
    }



    IEnumerator timing()
    {
        yield return new WaitForSeconds((float)(0.45));
        rb.velocity = (transform.right * 15) + (transform.up * 1);
        rb.gravityScale = 0.2f;
        pitchedOrNot = true;
    }

    void Update()
    {
        SwipeCheck();
        TapCheck();
        hopCap();
        updateBatteryImage();
        addCheck();
        strikeCheck();
    }

    void strikeCheck()
    {
        GameObject animation = GameObject.Find("batter_spritesheet_0");
        TriggerAnimation animationTriggeredCheck = animation.GetComponent<TriggerAnimation>();

        if (pitchedOrNot)
        {
            if(transform.position.x < -9.0)
            {
                swipedOrNot = true;
                animationTriggeredCheck.swingAllowed = true;
            }
        }
    }

    void FixedUpdate()
    {
        SwingContactsBall();
    }

    private void hopCap(){
        if(hopCount > 3){
            hopCount = 3;
        }
    }

    private ParticleSystem ballParticleInstance() {
        ParticleSystem particleInstance = Instantiate(hopParticles, rb.position, new Quaternion(0, 0, 0, 90));
        // particleInstance.transform = new Vector3(rb.position.x, rb.position.y - (float) 0.35);
        return particleInstance;
    }

    public void updateBatteryImage(){

        if(hopCount == 0){
            batteryIcon.sprite = batteryEmpty;
        }

        else if(hopCount == 1){
            batteryIcon.sprite = batteryOne;
        }

        else if(hopCount == 2){
            batteryIcon.sprite = batteryTwo;
        }

        else if (hopCount == 3){
            batteryIcon.sprite = batteryThree;
        }
    }

    private void TapCheck(){
        PauseMenu pausedOrNot = PauseMenu.GetComponent<PauseMenu>();

        if (!(pausedOrNot.GameIsPaused))
        {
            if(ballHit && hopCount > 0) {

                
                    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        SoundManagerScript.PlaySound("ballhop");
                        hopInstance = ballParticleInstance();
                        hopInstance.Play();
                        rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y + 33);
                        hopCount -= 1;
                    }
                            

                
            }
        }
    }

    public void addHop() {
        if (canAdd) {
            hopCount++;
            addLoc = rb.position.x;
            canAdd = false;
        }
    }

    private void addCheck() {
        if (rb.position.x > (addLoc + 2.5))
        {
        canAdd = true;
        }
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
                swipedOrNot = true;
            }
        }
    }

    void SwingContactsBall()
    {
        GameObject animation = GameObject.Find("batter_spritesheet_0");
        TriggerAnimation animationTriggeredCheck = animation.GetComponent<TriggerAnimation>();
        CalculateDistance = GetComponent<CalculateDistance>();

        if (swipedOrNot && animationTriggeredCheck.swingAllowed)
        {
            // enable CalculateDistance component
            CalculateDistance.enabled = true; 
  
            if (transform.position.x > -6.0051699)
            {
                Debug.Log("Game Over");
                animationTriggeredCheck.swingAllowed = false;
            }
            else if (transform.position.x >= -6.55 && transform.position.x <= -6.0051699)
            {
                // Level 5 force
                SoundManagerScript.PlaySound("metalbat");  
                PerfectHitEffect.SetActive(true);   
                rb.AddForce(-direction/timeInterval * swingForceLvl5);
                rb.gravityScale = 1;
                swipedOrNot = false;
                Debug.Log("lvl5");
                animationTriggeredCheck.swingAllowed = false;
                ballHit = true;
                hopCount = 3;

            }
            else if (transform.position.x >= -7.0948301 && transform.position.x <= -6.55)
            {
                // Level 4 force
                SoundManagerScript.PlaySound("metalbat");  
                PerfectHitEffect.SetActive(true);   
                rb.AddForce(-direction/timeInterval * swingForceLvl4);
                rb.gravityScale = 1;
                swipedOrNot = false;
                Debug.Log("lvl4");
                animationTriggeredCheck.swingAllowed = false;
                ballHit = true;
                hopCount = 3;

            }
            else if (transform.position.x >= -7.6396602 && transform.position.x <= -7.0948301)
            {
                // Level 3 force
                SoundManagerScript.PlaySound("metalbat");     
                rb.AddForce(-direction/timeInterval * swingForceLvl3);
                rb.gravityScale = 1;
                swipedOrNot = false;
                Debug.Log("lvl3");
                animationTriggeredCheck.swingAllowed = false;
                ballHit = true;
                hopCount = 3;

            }
            else if (transform.position.x >= -8.1844903 && transform.position.x <= -7.6396602)
            {
                // Level 2 force
                SoundManagerScript.PlaySound("metalbat");     
                rb.AddForce(-direction/timeInterval * swingForceLvl2);
                rb.gravityScale = 1;
                swipedOrNot = false;
                Debug.Log("lvl2");
                animationTriggeredCheck.swingAllowed = false;
                ballHit = true;
                hopCount = 3;

            }
            else if (transform.position.x >= -8.7293204 && transform.position.x <= -8.1844903)
            {
                // Level 1 force
                SoundManagerScript.PlaySound("metalbat");     
                rb.AddForce(-direction/timeInterval * swingForceLvl1);
                rb.gravityScale = 1;
                swipedOrNot = false;
                Debug.Log("lvl1");
                animationTriggeredCheck.swingAllowed = false;
                ballHit = true;
                hopCount = 3;

            }
            else
            {
                swipedOrNot = false;
            }
        }
    }
}
