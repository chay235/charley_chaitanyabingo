using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FillBingoBoard : MonoBehaviour
{
    TMP_Text[] myboard;


    private void OnEnable()
    {
        myboard = GetComponentsInChildren<TMP_Text>();

        if (Problem.Instance != null)
        {
            fillBoard();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void fillBoard()
    {
        for (int i = 0; i < 25; i++)
        {
            myboard[i].text = Problem.Instance.answerslist[i].ToString();
        }
    }
}
