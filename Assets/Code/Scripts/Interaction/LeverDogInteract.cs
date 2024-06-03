using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script para las 3 palancas del perro del puzzle de la electricidad
public class LeverDogInteract : MonoBehaviour
{
    public bool isActive;

    [SerializeField] private GameObject leverOffModel, leverOnModel;
    [SerializeField] private GameObject trapObject;

    public void Use(){
        if(!isActive) DeactivateAllLevers();
        isActive = !isActive;
        UpdateState();
    }

    private void DeactivateAllLevers(){
        LeverDogInteract[] levers = FindObjectsOfType<LeverDogInteract>();

        foreach (LeverDogInteract lever in levers){
            lever.isActive = false;
            lever.UpdateState();
        }
    }

    public void ActivateAllLevers(){
        LeverDogInteract[] levers = FindObjectsOfType<LeverDogInteract>();

        foreach (LeverDogInteract lever in levers){
            lever.isActive = true;
            lever.UpdateState();
        }
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
