using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pieTest1 : MonoBehaviour {

    public Image dial2;
    public ClickExaxampleLite m_manager;


    //private ClickExaxampleLite xaxa;

    //private float rotation;
    public float timeLeft;

    // Use this for initialization
    void Start () {
        //xaxa = manager.GetComponent<ClickExaxampleLite>();
        timeLeft = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        set();
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            m_manager.GameOver();
        }
    }

    void set() {
        //rotation = points / 100;
        //Debug.Log("points = " + points.ToString() + " rotation value " + rotation.ToString() + ".");
        //Debug.Log

        dial2.fillAmount = (10 - timeLeft) * 0.1f;
    }

}