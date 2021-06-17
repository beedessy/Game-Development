using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool paused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                Time.timeScale = 1;
            else
                Time.timeScale = 0;
            paused = !paused;
        }
    }

    public void PauseThisGame()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
    }

    public void ResumeThisGame()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }
}