using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneOnEventTrigger : MonoBehaviour
{
    public void SceneLoader(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
