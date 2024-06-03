using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPickItem : Interact
{
    [SerializeField] ItemPick itemPick;

    protected override void Init(){
        triggerTag = "Dog";
    }

    protected override void Action()
    {
        if (DogInventoryManager.sharedInstance.IsCarryingItem()) return;
        itemPick.DogPick();
    }

    protected override bool IsControllingActive(){
        return DogController.sharedInstance.controllingActive;
    }

    // Si el perro está llevando el item, no queremos ver la exlamación de que lo puede coger
    protected override void ConditionOnTrigger(){
        if (!DogInventoryManager.sharedInstance.IsCarryingItem()){
            exclamationModel.SetActive(true);
        } else{
            exclamationModel.SetActive(false);
        }
    }
}
