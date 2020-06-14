using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class ClickExaxampleLiteWear : MonoBehaviour
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
    public Image gameover;

    private int var1;
    private int var2;
    private int vybran;
    public int timeLimit;
    private string harvest;
    private int otvet;
    private int point;
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


        Debug.Log("proverka...");
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
            point = point - 1;
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
        ponext.text = point.ToString() + " points";
    }

    void varJudges(Text myText, Text myText2, Text myText3, Text myText4)
    {
        for (int i = 0; i < 4; i++)
        {
            number = Random.Range(1, 5);
            if (!x_var.Contains(number))
            {
                x_var[i] = number;
            }
            else
            {
                i--;
            }

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
        if (x_var[chosen] == 1)
        {
            enricc.text = otvet.ToString();
            Debug.Log("1 = " + otvet.ToString());
        }

        if (x_var[chosen] == 2)
        {
            enricc.text = otvetarray[0].ToString();
            Debug.Log("2 = " + otvetarray[0].ToString());
        }

        if (x_var[chosen] == 3)
        {
            enricc.text = otvetarray[1].ToString();
            Debug.Log("3 = " + otvetarray[1].ToString());
        }

        if (x_var[chosen] == 4)
        {
            enricc.text = otvetarray[2].ToString();
            Debug.Log("4 = " + otvetarray[2].ToString());
        }
    }

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
            number = Random.Range(2, 10) * Random.Range(2, 10);
            if (!otvetarray.Contains(number))
            {
                otvetarray[i] = number;
            }
            else
            {
                i--;
            }

        }
    }

    public void GameOver()
    {
        gameover.gameObject.SetActive(true);
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
        gameover.gameObject.SetActive(false);
        point = 0;
        restart.gameObject.SetActive(false);
    }
}
    

