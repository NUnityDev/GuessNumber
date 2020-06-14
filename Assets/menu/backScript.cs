using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class backScript : MonoBehaviour {

    public Button back;


    // Use this for initialization
    void Start () {
        Button menu = back.GetComponent<Button>();
        menu.onClick.AddListener(backToBed);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // timed game
    void backToBed () {
        SceneManager.LoadScene("menu");
    }

}
