using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    //this script deals with speed of both the bolts(player and enery), asteroids 
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

 
}
