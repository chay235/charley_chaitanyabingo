using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class Problem : MonoBehaviour
{

    public static Problem Instance;

    public int divisor2 = 2;
    public int divisor3 = 3;
    public int divisor10 = 10;

    public bool isEasy = false;
    public bool isMedium = false;
    public bool isHard = false;

    public  List<int> dividendlist = new List<int>(25);
    public  List<int> answerslist = new List<int>(25);

    public List<int> bingo_h1 = new List<int>(5);
    public List<int> bingo_h2 = new List<int>(5);
    public List<int> bingo_h3 = new List<int>(5);
    public List<int> bingo_h4 = new List<int>(5);   
    public List<int> bingo_h5 = new List<int>(5);

    public List<int> bingo_v1 = new List<int>(5);
    public List<int> bingo_v2 = new List<int>(5);
    public List<int> bingo_v3 = new List<int>(5);
    public List<int> bingo_v4 = new List<int>(5);
    public List<int> bingo_v5 = new List<int>(5);

    public List<int> bingo_d1 = new List<int>(5);
    public List<int> bingo_d2 = new List<int>(5);


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    IEnumerator logBingo()
    {
        yield return new WaitForSeconds(.5f);
        //printBingo();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(logBingo());
    }

    public void populateCorrectBingo()
    {
        for (int i = 0; i < 5; i++)
        {
            bingo_h1.Insert(i, answerslist[i]);
            bingo_h2.Insert(i, answerslist[i + 5]);
            bingo_h3.Insert(i, answerslist[i + 10]);
            bingo_h4.Insert(i, answerslist[i + 15]);
            bingo_h5.Insert(i, answerslist[i + 20]);
        }

            bingo_v1.Add(answerslist[0]);
            bingo_v2.Add(answerslist[1]);
            bingo_v3.Add(answerslist[2]);
            bingo_v4.Add(answerslist[3]);
            bingo_v5.Add(answerslist[4]);

            bingo_v1.Add(answerslist[5]);
            bingo_v2.Add(answerslist[6]);
            bingo_v3.Add(answerslist[7]);
            bingo_v4.Add(answerslist[8]);
            bingo_v5.Add(answerslist[9]);

            bingo_v1.Add(answerslist[10]);
            bingo_v2.Add(answerslist[11]);
            bingo_v3.Add(answerslist[12]);
            bingo_v4.Add(answerslist[13]);
            bingo_v5.Add(answerslist[14]);

            bingo_v1.Add(answerslist[15]);
            bingo_v2.Add(answerslist[16]);
            bingo_v3.Add(answerslist[17]);
            bingo_v4.Add(answerslist[18]);
            bingo_v5.Add(answerslist[19]);

            bingo_v1.Add(answerslist[20]);
            bingo_v2.Add(answerslist[21]);
            bingo_v3.Add(answerslist[22]);
            bingo_v4.Add(answerslist[23]);
            bingo_v5.Add(answerslist[24]);

            bingo_d1.Add(answerslist[0]);
            bingo_d1.Add(answerslist[6]);
            bingo_d1.Add(answerslist[12]);
            bingo_d1.Add(answerslist[18]);
            bingo_d1.Add(answerslist[24]);

            bingo_d2.Add(answerslist[4]);
            bingo_d2.Add(answerslist[8]);
            bingo_d2.Add(answerslist[12]);
            bingo_d2.Add(answerslist[16]);
            bingo_d2.Add(answerslist[20]);
    }

    public void printProblemAnswers()
    {
        string dstr = "dividend: ";
        foreach (int x in dividendlist)
        {
            dstr += x + "  ";
        }
        Debug.Log(dstr);

        string astr = "quotien: ";
        foreach (int y in answerslist)
        {
            astr += y + "  ";
        }
        Debug.Log(astr);
    }

    public void printBingo()
    {
        string h1 = "h1: ";
        foreach (int y in bingo_h1)
        {
            h1 += y + "  ";
        }
        
        string h2 = "h2: ";
        foreach (int y in bingo_h2)
        {
            h2 += y + "  ";
        }

        string h3 = "h3: ";
        foreach (int y in bingo_h3)
        {
            h3 += y + "  ";
        }

        string h4 = "h4: ";
        foreach (int y in bingo_h4)
        {
            h4 += y + "  ";
        }

        string h5 = "h5: ";
        foreach (int y in bingo_h5)
        {
            h5 += y + "  ";
        }


        string v1 = "v1: ";
        foreach (int y in bingo_v1)
        {
            v1 += y + "  ";
        }
  
        string v2 = "v2: ";
        foreach (int y in bingo_v2)
        {
            v2 += y + "  ";
        }

        string v3 = "v3: ";
        foreach(int y in bingo_v3)
        {
            v3 += y + "  ";
        }

        string v4 = "v4: ";
        foreach (int y in bingo_v4)
        {
            v4 += y + "  ";
        }

        string v5 = "v5: ";
        foreach (int y in bingo_v5)
        {
            v5 += y + "  ";
        }

        string d1 = "d1: ";
        foreach (int y in bingo_d1)
        {
            d1 += y + "  ";
        }

        string d2 = "d2: ";
        foreach (int y in bingo_d2)
        {
            d2 += y + "  ";
        }

        Debug.Log(h1);
        Debug.Log(h2);
        Debug.Log(h3);
        Debug.Log(h4);
        Debug.Log(h5);
        Debug.Log(v1);
        Debug.Log(v2);
        Debug.Log(v3);
        Debug.Log(v4);
        Debug.Log(v5);     
        Debug.Log(d1);
        Debug.Log(d2);
    }

    public void populateEasy()
    {
        isEasy = true;
        isMedium = false;
        isHard = false;

        int dividend;

        int i = 0;
        while(i < 25)
        {
            dividend = UnityEngine.Random.Range(0, 10);
            if (dividend % divisor2 == 0)
            {
                dividendlist.Insert(i, dividend);
                answerslist.Insert(i, (dividend/divisor2));
                i++;
            }
        }
    }

    public void populateMedium()
    {
        isMedium = true;
        isEasy = false;
        isHard = false;

        int dividend;

        int i = 0;
        while (i < 25)
        {
            dividend = UnityEngine.Random.Range(0, 25);
            if (dividend % divisor3 == 0)
            {
                dividendlist.Insert(i, dividend);
                answerslist.Insert(i, (dividend / divisor3));
                i++;
            }
        }
    }

    public void populateHard()
    {
        isHard = true;
        isEasy = false;
        isMedium = false;

        int dividend;

        int i = 0;
        while (i < 25)
        {
            dividend = UnityEngine.Random.Range(0, 100);
            if (dividend % divisor10 == 0)
            {
                dividendlist.Insert(i, dividend);
                answerslist.Insert(i, (dividend / divisor10));
                i++;
            }
        }
    }

    public void clearEverything()
    {
        answerslist.Clear();
        dividendlist.Clear();
        bingo_h1.Clear();
        bingo_h2.Clear();
        bingo_h3.Clear();
        bingo_h4.Clear();
        bingo_h5.Clear();
        bingo_v1.Clear();
        bingo_v2.Clear();
        bingo_v3.Clear();
        bingo_v4.Clear();
        bingo_v5.Clear();
        bingo_d1.Clear();
        bingo_d2.Clear();
    }

    public void resetVariables()
    {
        isEasy = false;
        isMedium = false;
        isHard = false;
    }
}
