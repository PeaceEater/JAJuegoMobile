using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script permite al perro dar un objeto al jugador
public class DogGiveItem : Interact
{
    [SerializeField] ItemPick itemPick;

    protected override void Init(){
        triggerTag = "Player";
    }

    protected override void Action()
    {
        if (!DogInventoryManager.sharedInstance.IsCarryingItem()) return;
        itemPick.DogGivePlayer();
    }

    protected override bool IsControllingActive(){
        return DogController.sharedInstance.controllingActive;
    }
}
