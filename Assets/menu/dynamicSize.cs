using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicSize : MonoBehaviour {

    public GameObject objectParent;

    private Vector2 r2d2;

	// Use this for initialization
	void Start () {
        r2d2 = new Vector2(Screen.height, Screen.width); // changes vector2 value to screen x and y
        objectParent.gameObject.transform.localScale = r2d2; // changes the object's size to the vector2
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
