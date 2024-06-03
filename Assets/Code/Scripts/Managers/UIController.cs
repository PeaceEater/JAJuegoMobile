using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController sharedInstance;

    [SerializeField] private Image[] playerItemsImg;
    [SerializeField] private Image interactImg, changeCharImg;
    [SerializeField] private Sprite interactPlayerSpr, interactDogSpr;
    [SerializeField] private Sprite changeToDogSpr, changeToPlayerSpr;
    [SerializeField] private GameObject circleDogVFX, circlePlayerVFX;

    private void Awake() {
        if (sharedInstance == null){
            sharedInstance = this;
        }
    }

    private void Start() {
        UpdateInventoryUI();
        UpdateVFX(); 
    }

    void Update()
    {
        if(SimpleInput.GetKey(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void UpdateButtonUI(){
        if (PlayerController.sharedInstance.controllingActive){
            interactImg.sprite = interactPlayerSpr;
            changeCharImg.sprite = changeToPlayerSpr;
        } else {
            interactImg.sprite = interactDogSpr;
            changeCharImg.sprite = changeToDogSpr;
        }
    }

    public void UpdateVFX(){
        if (PlayerController.sharedInstance.controllingActive){
            circlePlayerVFX.SetActive(true);
            circleDogVFX.SetActive(false);
        } else {
            circlePlayerVFX.SetActive(false);
            circleDogVFX.SetActive(true);
        }
    }

    public void UpdateInventoryUI(){
        List<Item> inventoryItems = PlayerInventoryManager.sharedInstance.playerItems;

        for (int i = 0; i < playerItemsImg.Length; i++){
            playerItemsImg[i].enabled = false;
        }

        for (int i = 0; i < inventoryItems.Count; i++){
            if (inventoryItems[i] != null){
                playerItemsImg[i].enabled = true;
                playerItemsImg[i].sprite = inventoryItems[i].sprite;
            } 
        }
    }
}
