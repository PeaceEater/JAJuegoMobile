using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPanelManager : MonoBehaviour
{
    [SerializeField] private ColorPanelInteract panel1, panel2, panel3;
    [SerializeField] private string[] correctColorCode;
    [SerializeField] private GameObject door;
    void Start()
    {
        
    }

    void Update()
    {
        if(panel1.CurrentColor() == correctColorCode[0] && panel2.CurrentColor() == correctColorCode[1] 
        && panel3.CurrentColor() == correctColorCode[2]){
            door.SetActive(false);
        }
    }
}
