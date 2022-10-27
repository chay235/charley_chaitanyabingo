using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseHintPanel : MonoBehaviour, IPointerClickHandler
{
    public GameObject hintPanel;

    public HintDots hintDots;

    public void OnPointerClick(PointerEventData eventData)
    {
        hintDots.clearBoard();
        hintPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        hintDots = GameObject.Find("DotPanel").GetComponent<HintDots>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
