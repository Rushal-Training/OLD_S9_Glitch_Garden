using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    public int starCost = 100;

    private StarDisplay starDisplay;

	void Start ()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Health>().health <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
}
