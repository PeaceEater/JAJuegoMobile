using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePuzzleInteract : MonoBehaviour
{
    [SerializeField] private GameObject throwableBonePrefab;
    [SerializeField] private Item itemNeeded;

    public void SpawnThrowableBone(){
        if(PlayerInventoryManager.sharedInstance.HasItem(itemNeeded)){
            PlayerInventoryManager.sharedInstance.Remove(itemNeeded);
            GameObject boneInstance = Instantiate(throwableBonePrefab);
            boneInstance.transform.parent = GameObject.Find("DynamicObjects").transform;
            boneInstance.GetComponent<ThrowableBone>().Throw();
            BonePuzzleEvent.sharedInstance.bonesThrowed++;
        }
    }
}
