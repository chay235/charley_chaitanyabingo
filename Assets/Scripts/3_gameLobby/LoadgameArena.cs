using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadgameArena : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject levelPanel;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        levelPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneLoader()
    {
        SceneManager.LoadScene("4_gameArena");
    }

    /*public void showLevelPanel()
    {
        levelPanel.SetActive(true);
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
        
    }*/

    IEnumerator showLevelPanel()
    {
        levelPanel.SetActive(true);
        yield return new WaitForSeconds(.1f);
        this.gameObject.SetActive(false);
    }

    public void loadLevel()
    {
        audioSource.Play();
        StartCoroutine(showLevelPanel());
    }

}
