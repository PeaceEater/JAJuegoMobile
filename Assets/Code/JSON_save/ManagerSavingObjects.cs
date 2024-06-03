using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 
using Newtonsoft.Json.Linq; 
using System.Security.Cryptography; 

public class ManagerSavingObjects : MonoBehaviour
{
    const string SAVE_FILE_NAME = "/json_save.sav";
    public DoorInteractPlayer door, door2;
    public PlayerInventoryManager inventory;
    public FuseInteraction fuseInteraction;
    public ItemsManager itemsManager;
    string saveFilePath;

    private void Start() {
        saveFilePath = Application.persistentDataPath + SAVE_FILE_NAME;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            JObject jSaveGame = new JObject();

            JObject serializedDoor = door.Serialize();
            jSaveGame.Add("door", serializedDoor);

            JObject serializedDoor2 = door2.Serialize();
            jSaveGame.Add("door2", serializedDoor2);

            JObject serializedInventory = inventory.Serialize();
            jSaveGame.Add("inventory", serializedInventory);

            JObject serializedFuseInteraction = fuseInteraction.Serialize();
            jSaveGame.Add("fuse", serializedFuseInteraction);

            JObject serializedItemManager = itemsManager.Serialize();
            jSaveGame.Add("itemManager", serializedItemManager);

            byte[] encryptSavegame = Encrypt(jSaveGame.ToString());
            File.WriteAllBytes(saveFilePath, encryptSavegame);
            Debug.Log("Saving to: " + saveFilePath);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            UIController.sharedInstance.UpdateInventoryUI();
            Debug.Log("Loading from: " + saveFilePath);

            byte[] decryptedSavegame = File.ReadAllBytes(saveFilePath);
            string jsonString = Decrypt(decryptedSavegame);

            JObject jSaveGame = JObject.Parse(jsonString);

            string doorJsonString = jSaveGame["door"].ToString();
            door.Deserialize(doorJsonString);

            string door2JsonString = jSaveGame["door2"].ToString();
            door2.Deserialize(door2JsonString);

            string inventoryJsonString = jSaveGame["inventory"].ToString();
            inventory.Deserialize(inventoryJsonString);

            string fuseInteractionJsonString = jSaveGame["fuse"].ToString();
            fuseInteraction.Deserialize(fuseInteractionJsonString);

            string itemManagerJsonString = jSaveGame["itemManager"].ToString();
            itemsManager.Deserialize(itemManagerJsonString);
        }

    }

    byte[] _key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
    byte[] _initializationVector = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

    byte[] Encrypt(string message)
    {
        AesManaged aes = new AesManaged();
        ICryptoTransform encryptor = aes.CreateEncryptor(_key, _initializationVector);
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        StreamWriter streamWriter = new StreamWriter(cryptoStream);

        streamWriter.WriteLine(message);

        streamWriter.Close();
        cryptoStream.Close();
        memoryStream.Close();

        return memoryStream.ToArray();
    }

    string Decrypt(byte[] message)
    {
        AesManaged aes = new AesManaged();
        ICryptoTransform decrypter = aes.CreateDecryptor(_key, _initializationVector);
        MemoryStream memoryStream = new MemoryStream(message);
        CryptoStream cryptoStream = new CryptoStream(memoryStream, decrypter, CryptoStreamMode.Read);
        StreamReader streamReader = new StreamReader(cryptoStream);

        string decryptedMessage = streamReader.ReadToEnd();

        streamReader.Close();
        cryptoStream.Close();
        memoryStream.Close();

        return decryptedMessage;
    }

}

