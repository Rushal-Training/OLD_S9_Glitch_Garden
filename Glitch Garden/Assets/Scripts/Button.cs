using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public static GameObject selectedDefender;
    public GameObject defenderPrefab;

    private Text costText;

	void Start ()
    {
        costText = GetComponentInChildren<Text>();

        if(!costText)
        {
            Debug.LogWarning(name + " has no cost text");
        }
        costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
        
	}
	
	void Update ()
    {
		
	}

    private void OnMouseDown()
    {
        foreach (Transform children in transform.parent)
        {
            if (children.GetComponent<SpriteRenderer>())
            {
                children.GetComponent<SpriteRenderer>().color = Color.black;

            }
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
