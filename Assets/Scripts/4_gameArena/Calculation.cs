using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calculation : MonoBehaviour
{
    Dividend dividend;
    Divisor divisor;
    Quotient quotient;

    public int currentLevelDivisor;
    public int i;
    public int currentquotient;


    // Start is called before the first frame update
    void Start()
    {

        dividend = GameObject.Find("dividend").GetComponent<Dividend>();
        divisor = GameObject.Find("divisor").GetComponent<Divisor>();
        quotient = GameObject.Find("quotient").GetComponent<Quotient>();

        if(Problem.Instance != null)
        {
            if (Problem.Instance.isEasy)
            {
                currentLevelDivisor = Problem.Instance.divisor2;
            }
            else if (Problem.Instance.isMedium)
            {
                currentLevelDivisor = Problem.Instance.divisor3;
            }
            else if (Problem.Instance.isHard)
            {
                currentLevelDivisor = Problem.Instance.divisor10;
            }
            else
            {
                currentLevelDivisor = Problem.Instance.divisor2;
            }

            updateProblem();
        }      
    }

   public void updateProblem()
    {
        i = UnityEngine.Random.Range(0, (Problem.Instance.dividendlist.Count) - 1);

        if (Problem.Instance.dividendlist.Count > 0 && Problem.Instance.dividendlist[i] != 00)
        {
            dividend.GetComponent<TMP_Text>().text = Problem.Instance.dividendlist[i].ToString();
            divisor.GetComponent<TMP_Text>().text = currentLevelDivisor.ToString();
            currentquotient = Problem.Instance.dividendlist[i] / currentLevelDivisor;
            quotient.GetComponent<TMP_Text>().text = currentquotient.ToString();
        }
        else
        {
            updateProblem();
        }
    }
}
