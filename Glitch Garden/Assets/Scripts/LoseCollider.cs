using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private SceneLoader sceneLoader;

	void Start () {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
	}

    private void OnTriggerEnter2D()
    {
        sceneLoader.LoadNextScene("00C Lose");
    }
}
