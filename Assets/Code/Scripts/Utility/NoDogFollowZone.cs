using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDogFollowZone : MonoBehaviour
{
    bool playerOnTrigger, dogOnTrigger;

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player")){
            playerOnTrigger = true;
        }
        if(other.CompareTag("Dog")){
            dogOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            playerOnTrigger = false;
        }
        if(other.CompareTag("Dog")){
            dogOnTrigger = false;
        }
    }

    private void Update() {
        if (playerOnTrigger && dogOnTrigger){
            DogFollowPlayer.sharedInstance.stopFollow = true;
        } else{
            DogFollowPlayer.sharedInstance.stopFollow = false;
        }
    }
}
