using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;

    void Start()
    {
        //Rotation of the asteroids at some random angular velocity
        //insideUnitsphere gives a random vector3 value by randomising them individually
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}