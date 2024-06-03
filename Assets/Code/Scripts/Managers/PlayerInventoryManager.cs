using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq; 
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    public static PlayerInventoryManager sharedInstance;
    public List<Item> playerItems = new List<Item>();

    private void Awake() {
        if (sharedInstance == null){
            sharedInstance = this;
        }
    }

    public void Add(Item item){
        playerItems.Add(item);
        UIController.sharedInstance.UpdateInventoryUI();
    }

    public void Remove(Item item){
        playerItems.Remove(item);
        UIController.sharedInstance.UpdateInventoryUI();
    }

    public bool HasItem(Item itemToCheck){
        return playerItems.Contains(itemToCheck);
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
