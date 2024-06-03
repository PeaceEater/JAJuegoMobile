using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    public static CharacterChange sharedInstance;

    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] Transform player, dog;
    public bool changeBlocked;

    void Awake() {
        if (sharedInstance == null){
            sharedInstance = this;
        }
    }

    void Update() {
        if (SimpleInput.GetKeyDown(KeyCode.F) && !changeBlocked){
            if (PlayerController.sharedInstance.controllingActive){
                PlayerController.sharedInstance.controllingActive = false;
                DogController.sharedInstance.controllingActive = true;
            } else {
                PlayerController.sharedInstance.controllingActive = true;
                DogController.sharedInstance.controllingActive = false;
            }
            UpdateCamTarget();
            UIController.sharedInstance.UpdateButtonUI();
            UIController.sharedInstance.UpdateVFX();
        }
    }

    void UpdateCamTarget(){
        StartCoroutine(CameraFollow.sharedInstance.InstantFollow(0.1f));
        if (PlayerController.sharedInstance.controllingActive) {
            cameraFollow.ChangeTarget(player);
        } else { 
            cameraFollow.ChangeTarget(dog);
        }
    }
}
