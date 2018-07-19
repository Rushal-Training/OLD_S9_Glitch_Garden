using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour {

    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
    }

    private void OnMouseDown()
    {
        //sceneLoader.LoadNextScene("01A Start Menu");
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            GameTimer.isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            GameTimer.isPaused = true;
        }
    }
}
