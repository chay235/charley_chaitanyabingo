using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadGameLobby : MonoBehaviour, IPointerClickHandler
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

        SceneManager.LoadScene("3_gameLobby");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.Play();
        StartCoroutine(SceneLoader());
    }
}
