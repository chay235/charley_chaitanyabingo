using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class HintQuestion : MonoBehaviour
{
    public string question;
    //Calculation calculation;

    Dividend dividend;
    Divisor divisor;

    public string hintText;
    public int dividendCount;


    private void OnEnable()
    {
        getHintText();
    }


    // Start is called before the first frame update
    void Start()
    {
        dividend = GameObject.Find("dividend").GetComponent<Dividend>();
        divisor = GameObject.Find("divisor").GetComponent<Divisor>();
 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getHintText()
    {
        hintText = " " + dividend.GetComponent<TMP_Text>().text + " % " + divisor.GetComponent<TMP_Text>().text + " = ?";

        question = hintText;
        GetComponent<TMP_Text>().text = question;

    }
}
