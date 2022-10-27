using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowHintPanel : MonoBehaviour, IPointerClickHandler

{
    public GameObject hintPanel;


    public void OnPointerClick(PointerEventData eventData)
    {
        hintPanel.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        hintPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
