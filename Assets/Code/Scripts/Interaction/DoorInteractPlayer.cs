using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq; 

public class DoorInteractPlayer : MonoBehaviour
{
    public bool isOpen; 

    [SerializeField] private Item itemNeeded;
    [SerializeField] private FloatingText floatingText;
    [SerializeField] private GameObject doorModel;

    private void Update() {
        if (isOpen){
            doorModel.SetActive(false);
        }
        if (doorModel != null){
            if (!doorModel.activeInHierarchy){
                isOpen = true;
            }
        }
    }

    public void Open(){
        if (PlayerInventoryManager.sharedInstance.HasItem(itemNeeded)){
            PlayerInventoryManager.sharedInstance.Remove(itemNeeded);
            isOpen = true;
            doorModel.SetActive(false);
        } else{
            floatingText.Show();
        }
    }

    public JObject Serialize()
    {
        string jsonString = JsonUtility.ToJson(this);
        JObject retVal = JObject.Parse(jsonString);
        return retVal;
    }

    public void Deserialize(string jsonString)
    {
        JsonUtility.FromJsonOverwrite(jsonString, this);
    }
}
