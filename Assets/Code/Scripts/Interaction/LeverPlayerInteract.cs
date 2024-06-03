using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPlayerInteract : MonoBehaviour
{
    public bool isActive;

    [SerializeField] private GameObject leverOffModel, leverOnModel;
    [SerializeField] private GameObject trapObject;

    public void Use(){
        isActive = !isActive;
        UpdateState();
        LeverDogInteract lever = FindObjectOfType<LeverDogInteract>();
        lever.ActivateAllLevers();
    }

    public void UpdateState(){
        if(isActive){
            trapObject.SetActive(false);
            leverOffModel.SetActive(false);
            leverOnModel.SetActive(true);
        } else {
            trapObject.SetActive(true);    
            leverOffModel.SetActive(true);
            leverOnModel.SetActive(false);
        }
    }
}
