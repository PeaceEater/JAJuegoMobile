using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq; 

public class ItemsManager : MonoBehaviour
{
    public bool bonePicked, keyPicked, fusePicked;
    public GameObject bone, key, fuse;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("BoneItem") == null){
            bonePicked = true;
        } 
        if(GameObject.Find("LlaveElectricidadItem") == null){
            keyPicked = true;
        } 
        if(GameObject.Find("FusibleItem") == null){
            fusePicked = true;
        } 

        if (bonePicked && bone != null){
            Destroy(bone);
        } else if(keyPicked && key != null){
            Destroy(key.gameObject);
        } else if(fusePicked && fuse != null){
            Destroy(fuse.gameObject);
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
