using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private int starAmount = 100;
    private Text starText;
    public enum Status { SUSSESS, FAILURE };

	void Start ()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

   public void AddStars(int amount)
    {
        starAmount += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if(starAmount >= amount && !GameTimer.isPaused)
        {
            starAmount -= amount;
            UpdateDisplay();
            return Status.SUSSESS;
        }

        return Status.FAILURE;

    }

    private void UpdateDisplay()
    {
        starText.text = starAmount.ToString();
    }
}
