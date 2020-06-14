using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pieTest1p : MonoBehaviour
{

    public Image dial2;
    //public Button addButton;

    //private float rotation;
    public float timeLeft;
    public int oldpoints;
    [HideInInspector] public Image dialImage;
    [HideInInspector] public float myFloatie;

    // Use this for initialization
    void Start()
    {
        myFloatie = 0;
        timeLeft = 0;
        InvokeRepeating("timelft", myFloatie, 0.1f);
        // Button ans1 = addButton.GetComponent<Button>();
        //ans1.onClick.AddListener(add);
        dialImage = GetComponentsInChildren<Image>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        set();
        //timeLeft = timeLeft - 0.1f;
    }

    void set()
    {
        //rotation = points / 100;
        //Debug.Log("points = " + points.ToString() + " rotation value " + rotation.ToString() + ".");
        //dial2.fillAmount = (10 - timeLeft) * 0.1f;
        dial2.fillAmount = timeLeft;
        //Debug.Log("rotation " + dial2.fillAmount + " timeleft " + timeLeft);
    }

    void add()
    {
        timeLeft = 0;

    }

    void timelft()
    {
        timeLeft = timeLeft + 0.01f;
    }

}
