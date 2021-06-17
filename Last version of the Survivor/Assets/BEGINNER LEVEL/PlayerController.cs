using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{   
    // declaring global variables used in the game 
    public Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;

    //spawn shots by ship
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    
    //health part of player health
    public int currentHealth;
    //  used in the inspecter to enter the hearts number
    public int maxHealth;

    void Start()
    {
        //gives access to rigidbody components in the player and engines player components
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //hit the spacebar to shot
        if ((Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire))
       
        //For firing bolts
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            //Add an audio source to the player when it fires
            GetComponent<AudioSource>().Play();

        }
    }


    void FixedUpdate()
    {
        if (HealthControlScript.health ==0)
        {
            Destroy(this.gameObject);
        }
       
        //allows movement of player through the keyboard arrows keys
        float moveHorizontal = Input.GetAxis("Horizontal");


        //allows movement of spaceship of player
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);

        //player is allowed to move faster
        rb.velocity = movement * speed;
        //set boundaries to prevent player spaceship from moving outside the boundaries
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
        // tilt value to the player
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}