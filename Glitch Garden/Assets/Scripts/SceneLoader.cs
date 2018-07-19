using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    private void Start()
    {
        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Auto level load disabled");
        }
        else
        {
            Invoke("LoadStartScene", autoLoadNextLevelAfter);
        }
    }

    public void LoadNextScene (string scene)
    {
        Initiate.Fade(scene, Color.black, 2.0f);
    }

    public void LoadStartScene ()
    {
        Initiate.Fade("01A Start Menu", Color.black, 1.0f);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
