using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class ClickExaxampleLite_timed : MonoBehaviour
{
    public InputField iField;
    public Text onext;
    public Text ponext;
    public Text denext;
    //public Button yourButton5;
    //public Button yourButton2;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button replay;
    //public Text res1;
    //public Text res2;
    //public Text res3;
    public Text btn1text;
    public Text btn2text;
    public Text btn3text;
    public Text btn4text;
    public Text timeText;


    private int var1;
    private int var2;
    private int vybran;
    public int timeLimit;
    private string harvest;
    private int otvet;
    private int point;
    private int hipoint;
    private int otvet2;
    private int otvet3;
    private int otvet4;
    private int r1;
    private int r2;
    private int r3;
    private int r4;
    private int n1;
    private int n2;
    private int n3;
    private int n4;
    private bool r1called;
    private bool r2called;
    private bool r3called;
    private bool r4called;
    private string r1e;
    private string r2e;
    private string r3e;
    private string r4e;
    private int game;
    public int number;
    Random random = new Random();
    int[] x_var = new int[10];
    int[] otvetarray = new int[10];

    float timeLeft = 5.0f;

    void Start()
    {
        //timeLimit = 000000;
        ponext.text = " ";
        Generate();
        point = 0;
        //Button btn = checkcall.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
        Button ans1 = btn1.GetComponent<Button>();
        ans1.onClick.AddListener(b1);
        Button ans2 = btn2.GetComponent<Button>();
        ans2.onClick.AddListener(b2);
        Button ans3 = btn3.GetComponent<Button>();
        ans3.onClick.AddListener(b3);
        Button ans4 = btn4.GetComponent<Button>();
        ans4.onClick.AddListener(b4);
        //Button rep = replay.GetComponent<Button>();
        //rep.onClick.AddListener(newChance);

        // randomy
        //genJdg();
        varJudges(btn1text,btn2text,btn3text,btn4text);
        //genJdg2();
        //Debug.Log("otvet is " + otvet + " otvet2 is " + otvet2 + " otvet3 is " + otvet3 + " otvet4 is " + otvet4);
        //Debug.Log("random otvet is " + judge + " otvet2 is " + judge2 + " otvet3 is " + judge3 + " otvet4 is " + judge4);
        //Debug.Log("random int out otvet is " + nio + " otvet2 is " + nio2 + " otvet3 is " + nio3 + " otvet4 is " + nio4);
        //replay.gameObject.SetActive(false);
    }

    void Update()
    {
        SetText();
        if (point == 30)
        {
            denext.text = "you win!";
            point = point + 32;
        }

        timeLeft -= Time.deltaTime;
        timeText.text = (timeLeft * game).ToString();
        if (timeLeft < 0)
        {
            GameOver();

        }

        //Input field harvesting method - © 2016 NUD inc.
        //harvest = iField.text;
        //vybran = int.Parse(harvest);
        //timeLimit = timeLimit + 1;
    }

    //void Generate()
    //{
        //var1 = Random.Range(2, 10);
        //var2 = Random.Range(2, 10);
        //otvet = var1 * var2;
        //Debug.Log(otvet);
        //onext.text = var1 + "x" + var2 + "=?";
        //otvet2 = Random.Range(2, 10) * var2;
        //otvet3 = var1 * Random.Range(2, 10);
        //otvet4 = Random.Range(2, 10) * var1;
        //genJdg();
        //varJudges(btn1text, btn2text, btn3text, btn4text);
    //}

    void Test()
    {
        Debug.Log("proverka...");
        if (vybran == otvet)
        {
            //denext.text = "valid";
            Debug.Log("yes");
            point = point + 1;
        }
        else
        {
            //denext.text = "invalid";
            Debug.Log("no");
            point = point - 1;
            //otvet = 0;
        }
        SetText();
        //int i = 0;
        Generate();
        varJudges(btn1text, btn2text, btn3text, btn4text);
        

    }




    void SetText()
    {
        ponext.text = point.ToString();
        //denext.text = "highscore" + hipoint.ToString() + "points";
    }

    //void TaskOnClick ()
    //{
    //	Test ();
    //	iField.text = " ";
    //}


    void varJudges(Text myText, Text myText2, Text myText3, Text myText4)
    {
        for (int i = 0; i < 4; i++)
        {
            //Debug.Log("i is " + i.ToString());
            number = Random.Range(1, 5);
            if (!x_var.Contains(number))
            {
                x_var[i] = number;

                //Debug.Log(number.ToString());
            }
            else
            {
                i--;
            }

            // debug?
             //myText.text = x_var[0].ToString();
             //myText2.text = x_var[1].ToString();
             //myText3.text = x_var[2].ToString();
             //myText4.text = x_var[3].ToString();

            

        }

        gen(myText, 0);
        gen(myText2, 1);
        gen(myText3, 2);
        gen(myText4, 3);
        for (int i = 0; i < 4; i++)
        {
            x_var[i] = 0;
        }
    }

    void b1() {
        timeLeft = 5.0f;
        game = 1;
        vybran = int.Parse(btn1text.text);
        Test();
    }

    void b2()
    {
        timeLeft = 5.0f;
        game = 1;
        vybran = int.Parse(btn2text.text);
        Test();
    }

    void b3()
    {
        timeLeft = 5.0f;
        game = 1;
        vybran = int.Parse(btn3text.text);
        Test();
    }

    void b4()
    {
        Test();
        timeLeft = 5.0f;
        game = 1;
        vybran = int.Parse(btn4text.text);
    }

    // void genJdg() {
        //gen1();
        //gen2();
        //r2called = true;
        //gen3();
        //r3called = true;
        //gen4();
        //r4called = true;
    // }

    void ifs () {
        btn1text.text = r1.ToString();
        btn2text.text = r2.ToString();
        btn3text.text = r3.ToString();
        btn4text.text = r4.ToString();
    }

    void gen1() {
        r1 = Random.Range(1, 5);
    }

    void gen2() {
        r2 = Random.Range(1, 5);
    }

    void gen3() {
        r3 = Random.Range(1, 5);
    }

    void gen4() {
        r4 = Random.Range(1, 5);
    }

    void gen(Text enricc, int chosen) {
        if (x_var[chosen] == 1) {
            enricc.text = otvet.ToString();
            Debug.Log("1 = " + otvet.ToString());
        }

        if (x_var[chosen] == 2) {
            enricc.text = otvetarray[0].ToString();
            Debug.Log("2 = " + otvetarray[0].ToString());
        }

        if (x_var[chosen] == 3) {
            enricc.text = otvetarray[1].ToString();
            Debug.Log("3 = " + otvetarray[1].ToString());
        }

        if (x_var[chosen] == 4) {
            enricc.text = otvetarray[2].ToString();
            Debug.Log("4 = " + otvetarray[2].ToString());
        }
    }

    //generate v2
    void Generate()
    {
        var1 = Random.Range(2, 10);
        var2 = Random.Range(2, 10);
        otvet = var1 * var2;
        Debug.Log(otvet);
        onext.text = var1 + "x" + var2 + "=?";

        otvetarray[3] = otvet;
        for (int i = 0; i < 3; i++)
        {
            //Debug.Log("i is " + i.ToString());
            number = Random.Range(2, 10) * Random.Range(2, 10);
            if (!otvetarray.Contains(number))
            {
                otvetarray[i] = number;

                //Debug.Log(number.ToString());
            }
            else
            {
                i--;
            }

            //otvetarray[0] = var1 * var2;

            // debug?
            //myText.text = x_var[0].ToString();
            //myText2.text = x_var[1].ToString();
            //myText3.text = x_var[2].ToString();
            //myText4.text = x_var[3].ToString();



        }

        

    }

    void GameOver()
    {
        onext.text = "game over";
        game = 0;
        btn1.interactable = false;
        btn2.interactable = false;
        btn3.interactable = false;
        btn4.interactable = false;
        vybran = 0;
        //replay.gameObject.SetActive(true);
    }

    void newChance () {
        game = 1;
        btn1.interactable = true;
        btn2.interactable = true;
        btn3.interactable = true;
        btn4.interactable = true;
        point = 0;
        //replay.gameObject.SetActive(false);
    }

}


