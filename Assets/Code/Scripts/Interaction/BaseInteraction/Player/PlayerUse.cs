using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUse : Interact
{ 
    [SerializeField] UnityEvent action;

    protected override void Init(){
        triggerTag = "Player";
    }

    protected override void Action(){
        action.Invoke();
        PlayerController.sharedInstance.anim.SetTrigger("use");
    }

    protected override bool IsControllingActive(){
        return PlayerController.sharedInstance.controllingActive;
    }
}
