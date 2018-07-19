using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private GameObject parent;
    private StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        parent = GameObject.Find("Defenders");

        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 pos = SnapToGrid(rawPos);
        int defenderCost = Button.selectedDefender.GetComponent<Defender>().starCost;

        if (Button.selectedDefender != null && starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUSSESS && !GameTimer.isPaused)
        {
            GameObject newDef = Instantiate(Button.selectedDefender, pos, Quaternion.identity);
            newDef.transform.parent = parent.transform;
        }
        else if (GameTimer.isPaused)
        {
            Debug.Log("Game is paused.  Unpause to continue");
        }
        else
        {
            Debug.Log("Insufficient stars to spawn");
        }

    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        int newX = Mathf.RoundToInt(rawWorldPos.x);
        int newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
