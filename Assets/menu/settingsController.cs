using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsController : MonoBehaviour {

    public Button about;
    public Button share;
    public Button source;
    public Button layout;
    public Text tlayout;

    private int nlayout;


    // Use this for initialization
    void Start () {
        Button abc = about.GetComponent<Button>();
        abc.onClick.AddListener(isAbout);
        Button shc = share.GetComponent<Button>();
        shc.onClick.AddListener(isShare);
        Button src = source.GetComponent<Button>();
        src.onClick.AddListener(isSource);
        Button lyc = layout.GetComponent<Button>();
        lyc.onClick.AddListener(isLayout);

        nlayout = 0;
    }
	
	// Update is called once per frame
	void Update () {
        tlayout.text = "LAYOUT " + nlayout.ToString();
	}

    void isAbout () {
        // nuSEB (Simulation of Expected Behaviour) v1
        Debug.Log("C 2017 nudev inc.");
    }

    void isShare () {
        Debug.Log("shared score of 3678475786495873478 to facebook.");
    }

    void isSource () {
        Debug.Log("github.com/eqgkrhsdj/guessnumber");
    }

    void isLayout () {
        nlayout = nlayout + 1;
    }
}
