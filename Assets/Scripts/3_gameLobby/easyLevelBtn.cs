using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class easyLevelBtn : MonoBehaviour, IPointerClickHandler
{
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator SceneLoader()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("4_gameArena");

        /*string astr = " ";
        foreach (int y in problem.answerslist)
        {
            astr += y + " ";
        }
        Debug.Log(astr);*/
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Problem.Instance.populateEasy();
        Problem.Instance.populateCorrectBingo();
        Problem.Instance.printProblemAnswers();
        Problem.Instance.printBingo();

        audioSource.Play();
        StartCoroutine(SceneLoader());
    }

}

