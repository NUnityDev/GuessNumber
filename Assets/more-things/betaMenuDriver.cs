using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for play button
using UnityEngine.SceneManagement; // for loading game scene

public class betaMenuDriver : MonoBehaviour {

    public Button plus;
    public Button minus;
    public Button divide;
    public Button multiply;

    // Use this for initialization
    void Start () {
        Button pls = plus.GetComponent<Button>();
        pls.onClick.AddListener(l_plus);
        Button mns = minus.GetComponent<Button>();
        mns.onClick.AddListener(l_minus);
        Button dvd = divide.GetComponent<Button>();
        dvd.onClick.AddListener(l_div);
        Button mlt = multiply.GetComponent<Button>();
        mlt.onClick.AddListener(l_mlt);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void l_mlt() {
        SceneManager.LoadScene("xaxabeta");
    }

    void l_div() {
        SceneManager.LoadScene("divide-scene");
    }

    void l_plus() {
        SceneManager.LoadScene("plus-scene");
    }

    void l_minus()
    {
        SceneManager.LoadScene("minus-scene");
    }
}
