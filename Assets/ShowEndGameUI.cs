using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowEndGameUI : MonoBehaviour
{
    public GameObject EndGameUI;
    int GameScene = 1;

    // Update is called once per frame
    void Update()
    {
        GameObject ballObject = GameObject.Find("Ball");
        CalculateDistance ballStopped = ballObject.GetComponent<CalculateDistance>();

        if (ballStopped.ballStopped)
        {
            EndGameUI.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        Debug.Log("Replay");
        EndGameUI.SetActive(false);
        SceneManager.LoadScene(GameScene);
        // Time.timeScale = 1f;
    }
}
