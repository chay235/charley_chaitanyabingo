using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HintDots : MonoBehaviour
{
    public string dividendCount;
    public int count;

    TMP_Text[] myboard;
    Dividend dividend;

    private void OnEnable()
    {
        fillBoard();
    }


    // Start is called before the first frame update
    void Start()
    {
        dividend = GameObject.Find("dividend").GetComponent<Dividend>();
        myboard = GetComponentsInChildren<TMP_Text>();
    }

    public void fillBoard()
    {
        dividendCount = dividend.GetComponent<TMP_Text>().text;

        count = Convert.ToInt32(dividendCount);
        for (int i = 0; i < count; i++)
        {
            myboard[i].text = "O";
        }
    }

    public void clearBoard()
    {
        for(int i = 0; i<90; i++)
        {
            myboard[i].text = null;
        }
    }
}
