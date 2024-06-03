using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq; 

public class FuseInteraction : MonoBehaviour
{
    [SerializeField] private Item fuse;
    [SerializeField] private GameObject trap, interact, fusible;
    [SerializeField] private FloatingText floatingText;
    public bool fusiblePlaced;

    private void Update() {
        if (fusiblePlaced){
            trap.SetActive(false);
            fusible.SetActive(true);
            Destroy(interact); // para que ya no puedas interactuar con el panel
        }
    }

    public void Put(){
        if (PlayerInventoryManager.sharedInstance.HasItem(fuse)){
            PlayerInventoryManager.sharedInstance.Remove(fuse);
            fusiblePlaced = true;
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
