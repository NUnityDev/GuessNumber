using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    public Button timed;
    public Button classic;


    // Use this for initialization
    void Start () {
        Button tmd = timed.GetComponent<Button>();
        tmd.onClick.AddListener(timedGame);
        Button cls = classic.GetComponent<Button>();
        cls.onClick.AddListener(classicGame);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // timed game
    void timedGame () {
        classic.interactable = false;
        SceneManager.LoadScene("timedxaxa");
    }

    // classic game
    void classicGame () {
        timed.interactable = false;
        SceneManager.LoadScene("classicxaxa");
    }

}
