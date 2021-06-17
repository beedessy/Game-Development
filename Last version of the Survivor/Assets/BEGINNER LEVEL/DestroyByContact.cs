using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    private HealthControlScript healthControlScript;
 
    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        if (explosion != null)
        {
            //Instantiate the explosion at the exact same position as the asteroid
            Instantiate(explosion, transform.position, transform.rotation);
        }
        {
            //if the player collides with the asteroid,instantiate the explosion
            if (other.tag == "player")
            {
                //Instantiate the explosion at the exact same position as the player
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

               
            }

            
            //destroy the asteroid
            // Destroy(other.gameObject);
            Destroy(gameObject);
        }
    } }
