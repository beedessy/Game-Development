using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagers : MonoBehaviour
{
   //declaring the different variable 
   //Displays text in UI
    public Text scoreText;
    public Text highScoreText;

    public float scoreAmount;
    public float pointIncreasedPerSecond;

    public GameObject bestBeaten;
    public string currentScoreLocation;
    // Start is called before the first frame update
    
    
    void Start()
    {   //Initialise the variables
       currentScoreLocation = CheckCurrentScene();//ckes which screen was loaded

        /*PlayerPrefs.SetInt("BestScore1", 0);//used to initialise all the scores to zero
        PlayerPrefs.SetInt("BestScore2", 0);
        PlayerPrefs.SetInt("BestScore3", 0);
        PlayerPrefs.Save();*/

        highScoreText.text = "Best Score: " + PlayerPrefs.GetInt(currentScoreLocation).ToString();//fetach beest score
        scoreAmount = 0f;
        pointIncreasedPerSecond = 1f;
    }

    //score function calculating score by points earned per time passed
    public void Score()
    {    
        if (!HealthControlScript.stopFlag)//checks for death in health controller
        {
         scoreText.text = "Score:" + (int)scoreAmount;
         scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
        }
        
    }

    //function to check which screen has been loaded and opens the best score accordingly
    public string CheckCurrentScene()
        {
        int index;
        index = SceneManager.GetActiveScene().buildIndex;

        switch (index)
        {
            case 2:
                
               return "BestScore1";

            case 3:
                
                return "BestScore2";

            case 4:
                return "BestScore3";

            default:

                return null;
        }

     }

    public void BestScore()
    { 
        
        Debug.Log(currentScoreLocation);

       if (scoreAmount > PlayerPrefs.GetInt(currentScoreLocation, 0))
        {
           ;
            PlayerPrefs.SetInt(currentScoreLocation, (int)scoreAmount);//saving the score and highscore
          
            highScoreText.text = "Best Score: "+ ((int)scoreAmount).ToString();
            PlayerPrefs.Save();
            bestBeaten.gameObject.SetActive(true);
        } 
    }
    void Update()
    {
        Score();
    }
}



