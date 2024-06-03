using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ColorPanelInteract : MonoBehaviour
{
    private string [] colors = new string[] {"red", "green", "blue"};
    [SerializeField] private int colorIndex = 0;
    [SerializeField] private GameObject redPanel, greenPanel, bluePanel;
    void Start()
    {
        UpdateColorPanel();
    }

    public void ChangeColor(){
        colorIndex++;
        colorIndex = colorIndex % 3;
        UpdateColorPanel();
    }

    void UpdateColorPanel(){
        if (colors[colorIndex] == "red"){
            redPanel.SetActive(true);
            greenPanel.SetActive(false);
            bluePanel.SetActive(false);
        } else if(colors[colorIndex] == "green"){
            redPanel.SetActive(false);
            greenPanel.SetActive(true);
            bluePanel.SetActive(false);
        } else {
            redPanel.SetActive(false);
            greenPanel.SetActive(false);
            bluePanel.SetActive(true);
        }
    }

    public string CurrentColor(){
        return colors[colorIndex];
    }
}
