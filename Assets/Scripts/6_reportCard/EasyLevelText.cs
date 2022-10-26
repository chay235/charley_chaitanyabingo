using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EasyLevelText : MonoBehaviour
{
    public string scoreText;

    private void OnEnable()
    {
        

    }

    // Start is called before the first frame update
    void Start()
    {
        updateReport();
        GetComponent<TMP_Text>().text = scoreText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateReport()
    {
        scoreText = "Answered correctly " + ScoreKeeper.Instance.problemCorrect + " out of " + ScoreKeeper.Instance.problemAttempted;
    }
}
