using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    //add a variable to set a lifetime for the gameobject
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        //destroy the gameobject to avoid accumulation of asteroids clone
        Destroy(gameObject, lifetime);
    }
}
