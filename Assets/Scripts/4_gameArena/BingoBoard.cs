using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BingoBoard : MonoBehaviour, IPointerClickHandler
{
    Calculation calculation;

    public GameObject gameOver;
    public GameObject bingo;
    
    public string mytmptext;
    public int myCurrentquotient;
    public string index;
    public int inttemp;

    public bool bingoPossible = true;
    public bool myBingo = false;

    public static bool h1 = true;
    public static bool h2 = true;
    public static bool h3 = true; 
    public static bool h4 = true;
    public static bool h5 = true;
    public static bool v1 = true;
    public static bool v2 = true;
    public static bool v3 = true;
    public static bool v4 = true;
    public static bool v5 = true;
    public static bool d1 = true;
    public static bool d2 = true;

    public static bool h_1 = false;
    public static bool h_2 = false;
    public static bool h_3 = false;
    public static bool h_4 = false;
    public static bool h_5 = false;
    public static bool v_1 = false;
    public static bool v_2 = false;
    public static bool v_3 = false;
    public static bool v_4 = false;
    public static bool v_5 = false;
    public static bool d_1 = false;
    public static bool d_2 = false;


    // Start is called before the first frame update
    void Start()
    {
        mytmptext = GetComponent<TMP_Text>().text;

        calculation = GameObject.Find("CalculationSingleton").GetComponent<Calculation>();

        index = this.name;
        inttemp = Convert.ToInt32(index);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        myCurrentquotient = calculation.currentquotient;

        if (mytmptext == Convert.ToString(myCurrentquotient))
        {
            Debug.Log(true);
            Debug.Log(index);
            Debug.Log(mytmptext);
            Debug.Log(GetComponentInParent<BingoBoard>().index);
            GetComponent<TMP_Text>().color = Color.green;

            Problem.Instance.dividendlist[inttemp] = 00;
            Problem.Instance.answerslist[inttemp] = 00;

            ScoreKeeper.Instance.incrementScore();
            ScoreKeeper.Instance.incrementProblemCount();
            //ScoreKeeper.Instance.calculatePercentage();

            displayToLog();

            markRight();
        }
        else
        {
            Debug.Log(false);
            Debug.Log(index);
            Debug.Log(mytmptext);
            Debug.Log(GetComponentInParent<BingoBoard>().index);

            Problem.Instance.dividendlist[inttemp] = 00;
            Problem.Instance.answerslist[inttemp] = 00;

            ScoreKeeper.Instance.incrementProblemCount();
            //ScoreKeeper.Instance.calculatePercentage();

            displayToLog();

            markWrong();

            Destroy(GetComponent<TMP_Text>());
        }

        calculation.updateProblem();
        ScoreKeeper.Instance.calculatePercentage();

        isBingo();
        isBingoPossible();
    }

    public void displayToLog()
    {
        string dstr = " ";
        foreach (int x in Problem.Instance.dividendlist)
        {
            dstr += x + "  ";
        }

        Debug.Log(dstr + "count: " + Problem.Instance.dividendlist.Count);

        string astr = " ";
        foreach (int y in Problem.Instance.answerslist)
        {
            astr += y + "  ";
        }

        Debug.Log(astr + "count: " + Problem.Instance.answerslist.Count);
    }

    public void isBingo()
    {
 
        h_1 = Problem.Instance.bingo_h1.TrueForAll(p => p == 00);
        h_2 = Problem.Instance.bingo_h2.TrueForAll(p => p == 00);
        h_3 = Problem.Instance.bingo_h3.TrueForAll(p => p == 00);
        h_4 = Problem.Instance.bingo_h4.TrueForAll(p => p == 00);
        h_5 = Problem.Instance.bingo_h5.TrueForAll(p => p == 00);
        v_1 = Problem.Instance.bingo_v1.TrueForAll(p => p == 00);
        v_2 = Problem.Instance.bingo_v2.TrueForAll(p => p == 00);
        v_3 = Problem.Instance.bingo_v3.TrueForAll(p => p == 00);
        v_4 = Problem.Instance.bingo_v4.TrueForAll(p => p == 00);
        v_5 = Problem.Instance.bingo_v5.TrueForAll(p => p == 00);
        d_1 = Problem.Instance.bingo_d1.TrueForAll(p => p == 00);
        d_2 = Problem.Instance.bingo_d2.TrueForAll(p => p == 00);

        if(h_1 || h_2 || h_3 || h_4 || h_5 || v_1 || v_2 || v_3 || v_4 || v_5 || d_1 || d_2)
        {
            myBingo = true;
            bingo.SetActive(true);
            ScoreKeeper.Instance.incrementBingo();
            Debug.Log("Bingo!");
            resetVariables();
            Problem.Instance.clearEverything();
            StartCoroutine(SceneLoader());
        }   
    }

    public void isBingoPossible()
    {
        /*h1 = Problem.Instance.bingo_h1.Count;
        h2 = Problem.Instance.bingo_h2.Count;
        h3 = Problem.Instance.bingo_h3.Count;
        h4 = Problem.Instance.bingo_h4.Count;
        h5 = Problem.Instance.bingo_h5.Count;

        v1 = Problem.Instance.bingo_v1.Count;
        v2 = Problem.Instance.bingo_v2.Count;
        v3 = Problem.Instance.bingo_v3.Count;
        v4 = Problem.Instance.bingo_v4.Count;
        v5 = Problem.Instance.bingo_v5.Count;

        d1 = Problem.Instance.bingo_d1.Count;
        d2 = Problem.Instance.bingo_d2.Count;*/

        if (h1==false && h2==false && h3==false && h4==false && h5==false && v1==false && v2==false && v3==false
            && v4==false && v5==false && d1==false && d2==false)
        {
            bingoPossible = false;
            gameOver.SetActive(true);
            Debug.Log("Game Over!");
            resetVariables();
            Problem.Instance.clearEverything();
            StartCoroutine(SceneLoader());
        }
    }

    public void markWrong()
    {
        if(inttemp == 0)
        {
            //Problem.Instance.bingo_h1.RemoveAt(0);
            //Problem.Instance.bingo_v1.RemoveAt(0);
            //Problem.Instance.bingo_d1.RemoveAt(0);
            if (h1 == true)
            {
                h1 = false;
            }
            if(v1 == true)
            {
                v1 = false;
            }
            if(d1 == true)
            {  
                d1 = false;
            }
        }
        else if(inttemp == 1)
        {
            //Problem.Instance.bingo_h1.RemoveAt(1);
            //Problem.Instance.bingo_v2.RemoveAt(0);
            if (h1 == true)
            {
                h1 = false;
            }
            if (v2 == true)
            {
                v2 = false;
            }
        }
        else if(inttemp == 2)
        {
            //Problem.Instance.bingo_h1.RemoveAt(2);
            //Problem.Instance.bingo_v3.RemoveAt(0);
            if (h1 == true)
            {
                h1 = false;
            }
            if (v3 == true)
            {
                v3 = false;
            }
        }
        else if(inttemp == 3)
        {
            //Problem.Instance.bingo_h1.RemoveAt(3);
            //Problem.Instance.bingo_v4.RemoveAt(0);
            if (h1 == true)
            {
                h1 = false;
            }
            if (v4 == true)
            {
                v4 = false;
            }
        }
        else if(inttemp == 4)
        {
            //Problem.Instance.bingo_h1.RemoveAt(4);
            //Problem.Instance.bingo_v5.RemoveAt(0);
            //Problem.Instance.bingo_d2.RemoveAt(0);
            if (h1 == true)
            {
                h1 = false;
            }
            if (v5 == true)
            {
                v5 = false;
            }
            if (d2 == true)
            {
                d2 = false;
            }
        }
        else if(inttemp == 5)
        {
            //Problem.Instance.bingo_h2.RemoveAt(0);
            //Problem.Instance.bingo_v1.RemoveAt(1);
            if (h2 == true)
            {
                h2 = false;
            }
            if (v1 == true)
            {
                v1 = false;
            }
        }
        else if(inttemp == 6)
        {
            //Problem.Instance.bingo_h2.RemoveAt(1);
            //Problem.Instance.bingo_v2.RemoveAt(1);
            //Problem.Instance.bingo_d1.RemoveAt(1);
            if (h2 == true)
            {
                h2 = false;
            }
            if (v2 == true)
            {
                v2 = false;
            }
            if (d1 == true)
            {
                d1 = false;
            }
        }
        else if (inttemp == 7)
        {
            //Problem.Instance.bingo_h2.RemoveAt(2);
            //Problem.Instance.bingo_v3.RemoveAt(1);
            if (h2 == true)
            {
                h2 = false;
            }
            if (v3 == true)
            {
                v3 = false;
            }
        }
        else if(inttemp == 8)
        {
            //Problem.Instance.bingo_h2.RemoveAt(3);
            //Problem.Instance.bingo_v4.RemoveAt(1);
            //Problem.Instance.bingo_d2.RemoveAt(1);
            if (h2 == true)
            {
                h2 = false;
            }
            if (v4 == true)
            {
                v4 = false;
            }
            if (d2 == true)
            {
                d2 = false;
            }
        }
        else if(inttemp == 9)
        {
            //Problem.Instance.bingo_h2.RemoveAt(4);
            //Problem.Instance.bingo_v5.RemoveAt(1);
            if (h2 == true)
            {
                h2 = false;
            }
            if (v5 == true)
            {
                v5 = false;
            }
        }
        else if(inttemp == 10)
        {
            //Problem.Instance.bingo_h3.RemoveAt(0);
            //Problem.Instance.bingo_v1.RemoveAt(2);
            if (h3 == true)
            {
                h3 = false;
            }
            if (v1 == true)
            {
                v1 = false;
            }
        }
        else if(inttemp == 11)
        {
            //Problem.Instance.bingo_h3.RemoveAt(1);
            //Problem.Instance.bingo_v2.RemoveAt(2);
            if (h3 == true)
            {
                h3 = false;
            }
            if (v2 == true)
            {
                v2 = false;
            }
        }
        else if(inttemp == 12)
        {
            //Problem.Instance.bingo_h3.RemoveAt(2);
            //Problem.Instance.bingo_v3.RemoveAt(2);
            //Problem.Instance.bingo_d1.RemoveAt(2);
            //Problem.Instance.bingo_d2.RemoveAt(2);
            if (h3 == true)
            {
                h3 = false;
            }
            if (v3 == true)
            {
                v3 = false;
            }
            if (d1 == true)
            {
                d1 = false;
            }
            if (d2 == true)
            {
                d2 = false;
            }
        }
        else if(inttemp == 13)
        {
            //Problem.Instance.bingo_h3.RemoveAt(3);
            //Problem.Instance.bingo_v4.RemoveAt(2);
            if (h3 == true)
            {
                h3 = false;
            }
            if (v4 == true)
            {
                v4 = false;
            }
        }
        else if(inttemp == 14)
        {
            //Problem.Instance.bingo_h3.RemoveAt(4);
            //Problem.Instance.bingo_v5.RemoveAt(2);
            if (h3 == true)
            {
                h3 = false;
            }
            if (v5 == true)
            {
                v5 = false;
            }
        }
        else if(inttemp == 15)
        {
            //Problem.Instance.bingo_h4.RemoveAt(0);
            //Problem.Instance.bingo_v1.RemoveAt(3);
            if (h4 == true)
            {
                h4 = false;
            }
            if (v1 == true)
            {
                v1 = false;
            }
        }
        else if(inttemp == 16)
        {
            //Problem.Instance.bingo_h4.RemoveAt(1);
            //Problem.Instance.bingo_v2.RemoveAt(3);
            //Problem.Instance.bingo_d2.RemoveAt(3);
            if (h4 == true)
            {
                h4 = false;
            }
            if (v2 == true)
            {
                v2 = false;
            }
            if (d2 == true)
            {
                d2 = false;
            }
        }
        else if(inttemp == 17)
        {
            //Problem.Instance.bingo_h4.RemoveAt(2);
            //Problem.Instance.bingo_v3.RemoveAt(3);
            if (h4 == true)
            {
                h4 = false;
            }
            if (v3 == true)
            {
                v3 = false;
            }
        }
        else if(inttemp == 18)
        {
            //Problem.Instance.bingo_h4.RemoveAt(3);
            //Problem.Instance.bingo_v4.RemoveAt(3);
            //Problem.Instance.bingo_d1.RemoveAt(3);
            if (h4 == true)
            {
                h4 = false;
            }
            if (v4 == true)
            {
                v4 = false;
            }
            if (d1 == true)
            {
                d1 = false;
            }
        }
        else if(inttemp == 19)
        {
            //roblem.Instance.bingo_h4.RemoveAt(4);
            //Problem.Instance.bingo_v5.RemoveAt(3);
            if (h4 == true)
            {
                h4 = false;
            }
            if (v5 == true)
            {
                v5 = false;
            }
        }
        else if(inttemp == 20)
        {
            //Problem.Instance.bingo_h5.RemoveAt(0);
            //Problem.Instance.bingo_v1.RemoveAt(4);
            //Problem.Instance.bingo_d2.RemoveAt(4);
            if (h5 == true)
            {
                h5 = false;
            }
            if (v1 == true)
            {
                v1 = false;
            }
            if (d2 == true)
            {
                d2 = false;
            }
        }
        else if(inttemp == 21)
        {
            //Problem.Instance.bingo_h5.RemoveAt(1);
            //Problem.Instance.bingo_v2.RemoveAt(4);
            if (h5 == true)
            {
                h5= false;
            }
            if (v2 == true)
            {
                v2 = false;
            }
        }
        else if(inttemp == 22)
        {
            //Problem.Instance.bingo_h5.RemoveAt(2);
            //Problem.Instance.bingo_v3.RemoveAt(4);
            if (h5 == true)
            {
                h5 = false;
            }
            if (v3 == true)
            {
                v3 = false;
            }
        }
        else if(inttemp == 23)
        {
            //Problem.Instance.bingo_h5.RemoveAt(3);
            //Problem.Instance.bingo_v4.RemoveAt(4);
            if (h5 == true)
            {
                h5 = false;
            }
            if (v4 == true)
            {
                v4 = false;
            }
        }
        else if(inttemp == 24)
        {
            //Problem.Instance.bingo_h5.RemoveAt(4);
            //Problem.Instance.bingo_v5.RemoveAt(4);
            //Problem.Instance.bingo_d1.RemoveAt(4);
            if (h5 == true)
            {
                h5 = false;
            }
            if (v5 == true)
            {
                v5 = false;
            }
            if (d1 == true)
            {
                d1 = false;
            }
        }
    }

    public void markRight()
    {
        if (inttemp == 0)
        {
            //Problem.Instance.bingo_h1.RemoveAt(0);
            //Problem.Instance.bingo_v1.RemoveAt(0);
            //Problem.Instance.bingo_d1.RemoveAt(0);
            Problem.Instance.bingo_h1[0] = 00;
            Problem.Instance.bingo_v1[0] = 00;
            Problem.Instance.bingo_d1[0] = 00;
        }
        else if (inttemp == 1)
        {
            //Problem.Instance.bingo_h1.RemoveAt(1);
            //Problem.Instance.bingo_v2.RemoveAt(0);
            Problem.Instance.bingo_h1[1] = 00;
            Problem.Instance.bingo_v2[0] = 00;
        }
        else if (inttemp == 2)
        {
            //Problem.Instance.bingo_h1.RemoveAt(2);
            //Problem.Instance.bingo_v3.RemoveAt(0);
            Problem.Instance.bingo_h1[2] = 00;
            Problem.Instance.bingo_v3[0] = 00;
        }
        else if (inttemp == 3)
        {
            //Problem.Instance.bingo_h1.RemoveAt(3);
            //Problem.Instance.bingo_v4.RemoveAt(0);
            Problem.Instance.bingo_h1[3] = 00;
            Problem.Instance.bingo_v4[0] = 00;
        }
        else if (inttemp == 4)
        {
            //Problem.Instance.bingo_h1.RemoveAt(4);
            //Problem.Instance.bingo_v5.RemoveAt(0);
            //Problem.Instance.bingo_d2.RemoveAt(0);
            Problem.Instance.bingo_h1[4] = 00;
            Problem.Instance.bingo_v5[0] = 00;
            Problem.Instance.bingo_d2[0] = 00;
        }
        else if (inttemp == 5)
        {
            //Problem.Instance.bingo_h2.RemoveAt(0);
            //Problem.Instance.bingo_v1.RemoveAt(1);
            Problem.Instance.bingo_h2[0] = 00;
            Problem.Instance.bingo_v1[1] = 00;
        }
        else if (inttemp == 6)
        {
            //Problem.Instance.bingo_h2.RemoveAt(1);
            //Problem.Instance.bingo_v2.RemoveAt(1);
            //Problem.Instance.bingo_d1.RemoveAt(1);
            Problem.Instance.bingo_h2[1] = 00;
            Problem.Instance.bingo_v2[1] = 00;
            Problem.Instance.bingo_d1[1] = 00;
        }
        else if (inttemp == 7)
        {
            //Problem.Instance.bingo_h2.RemoveAt(2);
            //Problem.Instance.bingo_v3.RemoveAt(1);
            Problem.Instance.bingo_h2[2] = 00;
            Problem.Instance.bingo_v3[1] = 00;
        }
        else if (inttemp == 8)
        {
            //Problem.Instance.bingo_h2.RemoveAt(3);
            //Problem.Instance.bingo_v4.RemoveAt(1);
            //Problem.Instance.bingo_d2.RemoveAt(1);
            Problem.Instance.bingo_h2[3] = 00;
            Problem.Instance.bingo_v4[1] = 00;
            Problem.Instance.bingo_d2[1] = 00;
        }
        else if (inttemp == 9)
        {
            //Problem.Instance.bingo_h2.RemoveAt(4);
            //Problem.Instance.bingo_v5.RemoveAt(1);
            Problem.Instance.bingo_h2[4] = 00;
            Problem.Instance.bingo_v5[1] = 00;
        }
        else if (inttemp == 10)
        {
            //Problem.Instance.bingo_h3.RemoveAt(0);
            //Problem.Instance.bingo_v1.RemoveAt(2);
            Problem.Instance.bingo_h3[0] = 00;
            Problem.Instance.bingo_v1[2] = 00;
        }
        else if (inttemp == 11)
        {
            //Problem.Instance.bingo_h3.RemoveAt(1);
            //Problem.Instance.bingo_v2.RemoveAt(2);
            Problem.Instance.bingo_h3[1] = 00;
            Problem.Instance.bingo_v2[2] = 00;
        }
        else if (inttemp == 12)
        {
            //Problem.Instance.bingo_h3.RemoveAt(2);
            //Problem.Instance.bingo_v3.RemoveAt(2);
            //Problem.Instance.bingo_d1.RemoveAt(2);
            //Problem.Instance.bingo_d2.RemoveAt(2);
            Problem.Instance.bingo_h3[2] = 00;
            Problem.Instance.bingo_v3[2] = 00;
            Problem.Instance.bingo_d1[2] = 00;
            Problem.Instance.bingo_d2[2] = 00;
        }
        else if (inttemp == 13)
        {
            //Problem.Instance.bingo_h3.RemoveAt(3);
            //Problem.Instance.bingo_v4.RemoveAt(2);
            Problem.Instance.bingo_h3[3] = 00;
            Problem.Instance.bingo_v4[2] = 00;
        }
        else if (inttemp == 14)
        {
            //Problem.Instance.bingo_h3.RemoveAt(4);
            //Problem.Instance.bingo_v5.RemoveAt(2);
            Problem.Instance.bingo_h3[4] = 00;
            Problem.Instance.bingo_v5[2] = 00;
        }
        else if (inttemp == 15)
        {
            //Problem.Instance.bingo_h4.RemoveAt(0);
            //Problem.Instance.bingo_v1.RemoveAt(3);
            Problem.Instance.bingo_h4[0] = 00;
            Problem.Instance.bingo_v1[3] = 00;
        }
        else if (inttemp == 16)
        {
            //Problem.Instance.bingo_h4.RemoveAt(1);
            //Problem.Instance.bingo_v2.RemoveAt(3);
            //Problem.Instance.bingo_d2.RemoveAt(3);
            Problem.Instance.bingo_h4[1] = 00;
            Problem.Instance.bingo_v2[3] = 00;
            Problem.Instance.bingo_d2[3] = 00;
        }
        else if (inttemp == 17)
        {
            //Problem.Instance.bingo_h4.RemoveAt(2);
            //Problem.Instance.bingo_v3.RemoveAt(3);
            Problem.Instance.bingo_h4[2] = 00;
            Problem.Instance.bingo_v3[3] = 00;
        }
        else if (inttemp == 18)
        {
            //Problem.Instance.bingo_h4.RemoveAt(3);
            //Problem.Instance.bingo_v4.RemoveAt(3);
            //Problem.Instance.bingo_d1.RemoveAt(3);
            Problem.Instance.bingo_h4[3] = 00;
            Problem.Instance.bingo_v4[3] = 00;
            Problem.Instance.bingo_d1[3] = 00;
        }
        else if (inttemp == 19)
        {
            //roblem.Instance.bingo_h4.RemoveAt(4);
            //Problem.Instance.bingo_v5.RemoveAt(3);
            Problem.Instance.bingo_h4[4] = 00;
            Problem.Instance.bingo_v5[3] = 00;
        }
        else if (inttemp == 20)
        {
            //Problem.Instance.bingo_h5.RemoveAt(0);
            //Problem.Instance.bingo_v1.RemoveAt(4);
            //Problem.Instance.bingo_d2.RemoveAt(4);
            Problem.Instance.bingo_h5[0] = 00;
            Problem.Instance.bingo_v1[4] = 00;
            Problem.Instance.bingo_d2[4] = 00;
        }
        else if (inttemp == 21)
        {
            //Problem.Instance.bingo_h5.RemoveAt(1);
            //Problem.Instance.bingo_v2.RemoveAt(4);
            Problem.Instance.bingo_h5[1] = 00;
            Problem.Instance.bingo_v2[4] = 00;
        }
        else if (inttemp == 22)
        {
            //Problem.Instance.bingo_h5.RemoveAt(2);
            //Problem.Instance.bingo_v3.RemoveAt(4);
            Problem.Instance.bingo_h5[2] = 00;
            Problem.Instance.bingo_v3[4] = 00;
        }
        else if (inttemp == 23)
        {
            //Problem.Instance.bingo_h5.RemoveAt(3);
            //Problem.Instance.bingo_v4.RemoveAt(4);
            Problem.Instance.bingo_h5[3] = 00;
            Problem.Instance.bingo_v4[4] = 00;
        }
        else if (inttemp == 24)
        {
            //Problem.Instance.bingo_h5.RemoveAt(4);
            //Problem.Instance.bingo_v5.RemoveAt(4);
            //Problem.Instance.bingo_d1.RemoveAt(4);
            Problem.Instance.bingo_h5[4] = 00;
            Problem.Instance.bingo_v5[4] = 00;
            Problem.Instance.bingo_d1[4] = 00;
        }
    }

    public void resetVariables()
    {
        h1 = true;
        h2 = true;
        h3 = true;
        h4 = true;
        h5 = true;
        v1 = true;
        v2 = true;
        v3 = true;
        v4 = true;
        v5 = true;
        d1 = true;
        d2 = true;

        h_1 = false;
        h_2 = false;
        h_3 = false;
        h_4 = false;
        h_5 = false;
        v_1 = false;
        v_2 = false;
        v_3 = false;
        v_4 = false;
        v_5 = false;
        d_1 = false;
        d_2 = false;

        bingoPossible = true;
        myBingo = false;
    }

    IEnumerator SceneLoader()
    {
        if (Problem.Instance.isEasy)
        {
            Problem.Instance.populateEasy();
        }
        else if (Problem.Instance.isMedium)
        {
            Problem.Instance.populateMedium();
        }
        else
        {
            Problem.Instance.populateHard();
        }

        Problem.Instance.populateCorrectBingo();
        Problem.Instance.printProblemAnswers();
        Problem.Instance.printBingo();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("4_gameArena");
    }
}
