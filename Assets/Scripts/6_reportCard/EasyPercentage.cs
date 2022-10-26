using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EasyPercentage : MonoBehaviour
{
    public string percentage;

    private void OnEnable()
    {
        

    }

    // Start is called before the first frame update
    void Start()
    {
        updatePercentage();
        GetComponent<TMP_Text>().text = percentage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatePercentage()
    {
        percentage = ScoreKeeper.Instance.percentageCorrect + " %";
    }
}
