using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    public static ScoreKeeper Instance;

    public float problemCorrect = 0;
    public float problemAttempted = 0;
    public float percentageCorrect = 0;

    public int gotBingo = 0;



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementScore()
    {
        problemCorrect++;
    }

    public void incrementProblemCount()
    {
        problemAttempted++;
    }

    public void calculatePercentage()
    {
        percentageCorrect =  (problemCorrect / problemAttempted) * 100;
    }

    public void incrementBingo()
    {
        gotBingo++;
    }
}
