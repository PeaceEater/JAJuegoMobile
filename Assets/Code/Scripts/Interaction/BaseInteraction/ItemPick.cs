using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    public Item item;
    public Event itemPick;

    public void PlayerPick(){
        itemPick.Ocurred(gameObject);
        
        PlayerInventoryManager.sharedInstance.Add(item);
        if (DogInventoryManager.sharedInstance.HasItem(item)){
            DogInventoryManager.sharedInstance.RemoveItem();
        }
        Destroy(gameObject);
    }

    public void DogGivePlayer(){
        PlayerInventoryManager.sharedInstance.Add(item);
        DogInventoryManager.sharedInstance.RemoveItem();
        Destroy(gameObject);
    }

    public void DogPick(){
        DogInventoryManager.sharedInstance.dogItem = item;
        ItemInDogMouth();
    }

    private void ItemInDogMouth(){
        transform.SetParent(DogInventoryManager.sharedInstance.itemCarryParent, true);
        transform.localPosition = new Vector3(0, 0.1f, 0.35f);
        transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
