using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for play button
using UnityEngine.SceneManagement; // for loading game scene

public class welcome : MonoBehaviour {

	public Button play;

	// Use this for initialization
	void Start () {
		Button ply = play.GetComponent<Button>();
		ply.onClick.AddListener(next);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void next() {
		SceneManager.LoadScene("xaxalite7");
	}
}
