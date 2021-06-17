using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    // reduce the accumulation of shots on the hierarchy by destroying them as they leave the box collider's trigger volume.
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
