using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 100f;
    public static bool isPaused = false;

    private Slider slider;
    private SceneLoader sceneLoader;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private GameObject winText;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        slider = GetComponent<Slider>();
        winText = GameObject.Find("Win Text");

        if (!winText)
        {
            Debug.LogWarning("Please create new win text object");
        }

        winText.SetActive(false);
    }
	
	void Update ()
    {        
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        Win();
	}

    void Win()
    {
        if(Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            DestroyAllTaggedObjects();
            audioSource.Play();
            winText.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            isEndOfLevel = true;
        }
    }

    void DestroyAllTaggedObjects()
    {
        foreach (GameObject withTag in GameObject.FindGameObjectsWithTag("destroyOnWin"))
        {
            Destroy(withTag);
        }
    }

    void LoadNextLevel ()
    {
        sceneLoader.LoadNextScene("02 Level-02");
    }
}
