using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelBtnScript : MonoBehaviour
{

    public GameObject levelPanel;

    // Start is called before the first frame update
    void Start()
    {
        levelPanel.SetActive(false);
    }

    
    public void showLevelPanel()
    {
        levelPanel.SetActive(true);
    }

    public void easyLevel()
    {
        SceneManager.LoadScene("4_gameArena");
    }

    public void mediumLevel()
    {
        SceneManager.LoadScene("4_gameArena");
    }

    public void hardLevel()
    {
        SceneManager.LoadScene("4_gameArena");

    }
}
