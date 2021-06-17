using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{//when collision occurs on the player one life is removed
    private void OnTriggerEnter()
    {
        HealthControlScript.health -= 1;
    }
}