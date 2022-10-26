using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadPetPen : MonoBehaviour, IPointerClickHandler
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    IEnumerator SceneLoader()
    {
        yield return new WaitForSeconds(.2f);

        SceneManager.LoadScene("5_petPen");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.Play();
        StartCoroutine(SceneLoader());
    }
}
