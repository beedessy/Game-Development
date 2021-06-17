using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;


  
    void Start()
    {    //Call spawnWaves from the startfunction
        //create a barrage of asteroid to spawn one after the other by using the caroutine function
        StartCoroutine(SpawnWaves());

        Debug.Log(PlayerPrefs.GetInt("Best Score"));
       
    }

    
    IEnumerator SpawnWaves()
    {
        //pause the game for a few seconds at the start for the player to get ready to shoot the asteroids 

        yield return new WaitForSeconds(startWait);

        //create an infinite loop using the while function to continue having the asteroids moving towards the player until it is destroyed

        while (true)
        {

            //adding a for loop to create several hazards spawning at the same time
            for (int i = 0; i < hazardCount; i++)
            {

                //sprawning n number of hazards.
                //set the spawnposition.x of the asteroids to a random value
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                //pause the game for a few seconds after a few asteroids move towards the player
                yield return new WaitForSeconds(spawnWait);

            }

            //wait a few seconds after each wave of asteroids has move towards the player
            yield return new WaitForSeconds(waveWait);
        }
    }


 

}
