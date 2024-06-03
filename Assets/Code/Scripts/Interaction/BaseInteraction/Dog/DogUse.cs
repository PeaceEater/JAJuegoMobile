using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DogUse : Interact
{
    [SerializeField] UnityEvent action;

    protected override void Init(){
        triggerTag = "Dog";
    }

    protected override void Action()
    {
        action.Invoke();
    }

    protected override bool IsControllingActive(){
        return DogController.sharedInstance.controllingActive;
    }
}
