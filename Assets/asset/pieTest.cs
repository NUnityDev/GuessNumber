using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pieTest : MonoBehaviour {

    public Image dial;
    public Button addButton;

    //private float rotation;
    public int points;
    public int oldpoints;

	// Use this for initialization
	void Start () {
        points = 0;
        Button ans1 = addButton.GetComponent<Button>();
        ans1.onClick.AddListener(add);
    }
	
	// Update is called once per frame
	void Update () {
        set();
	}

    void set() {
        //rotation = points / 100;
        //Debug.Log("points = " + points.ToString() + " rotation value " + rotation.ToString() + ".");
        dial.fillAmount = points * 0.01f;
    }

    void add() {
        points = points + 1;
        Debug.Log("added 1 point.");
    }

}
