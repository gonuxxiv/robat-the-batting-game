using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public Button PauseButton;
    public Button PitchBallButton;
    public int MainMenuScene = 0;
    public int GameScene = 1;
    public int SettingsScene = 2;
    Movement BallMovementScript;

    // void Update()
    // {
    //     Button btn = PauseButton.GetComponent<Button>();
    //     PauseButton.onClick.AddListener(ButtonOnClick);
    // }

    void ButtonOnClick()
    {
        if (GameIsPaused)
        {
            Resume();
        } else 
        {
            Pause();
        }
    }

    public void Resume()
    {
        GameObject ballObject = GameObject.Find("Ball");
        Movement BallMovementScript = ballObject.GetComponent<Movement>();

        if (!BallMovementScript.pitchedOrNot)
        {
            PitchBallButton.gameObject.SetActive(true);
        }
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameResumes();
    }

    void GameResumes()
    {
        StartCoroutine(TimeCount());
    }


    IEnumerator TimeCount()
    {
        yield return new WaitForSeconds((float)(0.5));
        GameIsPaused = false;
    }

    public void Pause()
    {
        GameObject ballObject = GameObject.Find("Ball");
        Movement BallMovementScript = ballObject.GetComponent<Movement>();

        if (!BallMovementScript.pitchedOrNot)
        {
            PitchBallButton.gameObject.SetActive(false);
        }
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene(MainMenuScene);
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void LoadSettings()
    {
        Debug.Log("Loading Settings...");
        SceneManager.LoadScene(SettingsScene);
    }

    public void OnClickSound()
    {
        SoundManagerScript.PlaySound("clickSound");  
    }
}
