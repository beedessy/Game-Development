using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthControlScript : MonoBehaviour
{ //declaring global variables
    public GameObject Heart1, Heart2, Heart3, Heart4, Heart5, gameOver;
    public int numberOfHearts;
    public static int health;
    public ScoreManagers highestScore;
    public static bool stopFlag;
    private float timer = 2;
    private float changeTime = 2;


    void Start()
    {   //Initialising all the variables. Enabling display of Hearts and disabling Game over when game starts
        //timer is to pause the screen before changing scene.
        timer = 2;
        health = 6;
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3.gameObject.SetActive(true);
        Heart4.gameObject.SetActive(true);
        Heart5.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        stopFlag = false;

    }

    // Update is called once per frame
    void Update()
    {
        //checks that the player has  number of hearts equal to the number of hearts set in the inspector. Depending on level.
        if
         (health > numberOfHearts)
            health = numberOfHearts;
        // as game is played the number of heart decreases and hence after each frame it checks to disable the hearts until zero hearts
        switch (health)
        {

            case 5:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(true);
                Heart5.gameObject.SetActive(true);
                gameOver.gameObject.SetActive(false);

                break;
            case 4:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(true);
                Heart5.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(false);

                break;
            case 3:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(false);
                Heart5.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(false);

                break;
            case 2:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);
                Heart4.gameObject.SetActive(false);
                Heart5.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(false);

                break;
            case 1:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                Heart4.gameObject.SetActive(false);
                Heart5.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(false);

                break;
            case 0:
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                Heart4.gameObject.SetActive(false);
                Heart5.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                highestScore.BestScore();
                //Time.timeScale = 0;

                break;

        }

        if (health <= 0 && stopFlag == false)
        {//flags to stop the game after game over
            stopFlag = true;
        }

        if (stopFlag == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            //waits and set time before changing screens  
            timer = changeTime;
            SceneManager.LoadScene(5);
        }

    }
}