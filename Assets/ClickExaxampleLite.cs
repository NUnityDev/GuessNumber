using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class ClickExaxampleLite : MonoBehaviour
{
    public InputField iField;
    public Text onext;
    public Text ponext;
    public Text denext;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Text btn1text;
    public Text btn2text;
    public Text btn3text;
    public Text btn4text;
    public GameObject timeDial;
    public GameObject pointDial;
    public GameObject wrongCircle;
    public GameObject rightCircle;
    public Button restart;
    public Image winner;

    private int var1;
    private int var2;
    private int vybran;
    public int timeLimit;
    private string harvest;
    private int otvet;
    public int point;
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
    private bool game;
    Random random = new Random();
    int[] x_var = new int[10];
    int[] otvetarray = new int[10];
    private int number;
    private bool isExecuted;
    // backups for game stopping and resuming
    private float backupTime;
    private int backupPoints;
   
    void Start()
    {
        game = true;
        ponext.text = " ";
        Generate();
        point = 0;
        Button ans1 = btn1.GetComponent<Button>();
        ans1.onClick.AddListener(b1);
        Button ans2 = btn2.GetComponent<Button>();
        ans2.onClick.AddListener(b2);
        Button ans3 = btn3.GetComponent<Button>();
        ans3.onClick.AddListener(b3);
        Button ans4 = btn4.GetComponent<Button>();
        ans4.onClick.AddListener(b4);
        Button reboot = restart.GetComponent<Button>();
        reboot.onClick.AddListener(Restart);

        // randomy
        varJudges(btn1text, btn2text, btn3text, btn4text);
        isExecuted = false;
        wrongCircle.SetActive(false);
        rightCircle.SetActive(false);
        restart.gameObject.SetActive(false);
        winner.gameObject.SetActive(false);
    }

    void Update()
    {
        pieTest1p ptest = timeDial.GetComponent<pieTest1p>();
        SetText();
        if (point == 100)
        {
            winner.gameObject.SetActive(true);
            game = false;
            btn1.interactable = false;
            btn2.interactable = false;
            btn3.interactable = false;
            btn4.interactable = false;
            vybran = 0;
            point = 0;
            restart.gameObject.SetActive(true);
            rightCircle.SetActive(false);
        }

        //Input field harvesting
        pieTest pt = pointDial.GetComponent<pieTest>();
        pt.points = point;
        
            if (ptest.timeLeft > 1)
            {
                GameOver();
            }


    }

    IEnumerator Test()
    {
        pieTest1p ptest = timeDial.GetComponent<pieTest1p>();


        Debug.Log("checking...");
        if (vybran == otvet)
        {
            if (point < 100)
            {
                point = point + 1;
                rightCircle.SetActive(true);
                yield return new WaitForSeconds(1);
                rightCircle.SetActive(false);
                ptest.timeLeft = 0;
            }
        }
        else
        {
            if (point < 0) {
                point = 0;
            } else {
                point = point - 1;
            }
            wrongCircle.SetActive(true);
            yield return new WaitForSeconds(1);
            wrongCircle.SetActive(false);
            ptest.timeLeft = 0;

        }
        ptest.timeLeft = 0.0f;
        SetText();
        Generate();
        varJudges(btn1text, btn2text, btn3text, btn4text);
    }




    void SetText()
    {
        ponext.text = point.ToString() + " POINTS";
    }

    void varJudges(Text myText, Text myText2, Text myText3, Text myText4)
    {
        // loop 4 times
        for (int i = 0; i < 4; i++)
        {
            //create a random number
            number = Random.Range(1, 5);
            //check it against our number array
            if (!x_var.Contains(number))
            {
                //this means there is no entry with the number in the array
                //we'll just assign it
                x_var[i] = number;
            }
            else
            {
                // this means there is an entry with the number in the array
                // let's run it again!
                i--;
            }

        }

        // what is this
        gen(myText, 0);
        gen(myText2, 1);
        gen(myText3, 2);
        gen(myText4, 3);

        // zero out the number array because we don't need the values anymore
        for (int i = 0; i < 4; i++)
        {
            x_var[i] = 0;
        }
    }

    void b1()
    {
        vybran = int.Parse(btn1text.text);
        StartCoroutine(Test());
    }

    void b2()
    {
        vybran = int.Parse(btn2text.text);
        StartCoroutine(Test());
    }

    void b3()
    {
        vybran = int.Parse(btn3text.text);
        StartCoroutine(Test());
    }

    void b4()
    {
        vybran = int.Parse(btn4text.text);
        StartCoroutine(Test());
    }


    void ifs()
    {
        btn1text.text = r1.ToString();
        btn2text.text = r2.ToString();
        btn3text.text = r3.ToString();
        btn4text.text = r4.ToString();
    }

    void gen1()
    {
        r1 = Random.Range(1, 5);
    }

    void gen2()
    {
        r2 = Random.Range(1, 5);
    }

    void gen3()
    {
        r3 = Random.Range(1, 5);
    }

    void gen4()
    {
        r4 = Random.Range(1, 5);
    }

    void gen(Text enricc, int chosen)
    {
        // here's where the magic happens
        // if the entry 'chosen' in the array is equal to...

        //1, then
        if (x_var[chosen] == 1)
        {
            // this text is the lucky one
            // because it has the right answer
            enricc.text = otvet.ToString();
            // probably a debug leftover
            //Debug.Log("1 = " + otvet.ToString());
        }
        //if 2, then
        if (x_var[chosen] == 2)
        {
            // set wrong answer 1 as text value
            enricc.text = otvetarray[0].ToString();
            // probably a debug leftover
            //Debug.Log("2 = " + otvetarray[0].ToString());
        }
        //if 3, then
        if (x_var[chosen] == 3)
        {
            // set wrong answer 2 as text value
            enricc.text = otvetarray[1].ToString();
            // probably a debug leftover
            //Debug.Log("3 = " + otvetarray[1].ToString());
        }
        //if 4, then
        if (x_var[chosen] == 4)
        {
            // set wrong answer 3 as text value
            enricc.text = otvetarray[2].ToString();
            // probably a debug leftover
            //Debug.Log("4 = " + otvetarray[2].ToString());
        }
    }

    void Generate()
    {
        // let's actually generate our numbers!
        // make some random numbers
        var1 = Random.Range(2, 10);
        var2 = Random.Range(2, 10);
        // set right answer
        otvet = var1 * var2;
        // for some reason output the right answer,
        // probably also debug...
        //Debug.Log(otvet);
        //set the text
        onext.text = var1 + "x" + var2;

        // set the right answer as value 4 in the answer array 
        otvetarray[3] = otvet;
        // loop 3 times
        for (int i = 0; i < 3; i++)
        {
            // create a random answer
            number = Random.Range(2, 10) * Random.Range(2, 10);
            //check it against our number array
            if (!otvetarray.Contains(number))
            {
                //this means there is no entry with the number in the array
                //we'll just assign it
                otvetarray[i] = number;
            }
            else
            {
                // this means there is an entry with the number in the array
                // let's run it again!
                i--;
            }

        }
    }

    public void GameOver()
    {
        onext.text = "GAME\nOVER";
        game = false;
        btn1.interactable = false;
        btn2.interactable = false;
        btn3.interactable = false;
        btn4.interactable = false;
        vybran = 0;
        restart.gameObject.SetActive(true);
        //replay.gameObject.SetActive(true);
    }

    public void Restart()
    {
        pieTest1p ptest = timeDial.GetComponent<pieTest1p>();
        ptest.timeLeft = 0;
        game = true;
        btn1.interactable = true;
        btn2.interactable = true;
        btn3.interactable = true;
        btn4.interactable = true;
        SetText();
        Generate();
        varJudges(btn1text, btn2text, btn3text, btn4text);
        winner.gameObject.SetActive(false);
        point = 0;
        restart.gameObject.SetActive(false);
    }
}
    

