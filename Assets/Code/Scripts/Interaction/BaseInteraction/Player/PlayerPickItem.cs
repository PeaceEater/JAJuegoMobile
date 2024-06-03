using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickItem : Interact
{ 
    [SerializeField] ItemPick itemPick;

    protected override void Init(){
        triggerTag = "Player";
    }

    protected override void Action(){
        itemPick.PlayerPick();
        PlayerController.sharedInstance.anim.SetTrigger("interact");
    }

    protected override bool IsControllingActive(){
        return PlayerController.sharedInstance.controllingActive;
    }
}
