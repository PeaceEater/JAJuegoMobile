using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInventoryManager : MonoBehaviour
{
    public Item dogItem;
    public Transform itemCarryParent;
    public static DogInventoryManager sharedInstance;

    private void Awake() {
        if (sharedInstance == null){
            sharedInstance = this;
        }
    }

    public bool IsCarryingItem(){
        return dogItem != null;
    }

    public void RemoveItem(){
        GameObject itemGameObject = itemCarryParent.GetChild(0).gameObject;
        
        if (itemGameObject != null){
            Destroy(itemGameObject);
        }

        dogItem = null;
    }

    public bool HasItem(Item item){
        return dogItem == item;
    }
}
