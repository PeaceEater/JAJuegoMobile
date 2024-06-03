using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayersLayers : MonoBehaviour
{
    [SerializeField] GameObject playerModel, dogModel;
    bool playerOnTrigger;

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player")){
            playerOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            playerOnTrigger = false;
        }
    }

    private void Update() {
        if (playerOnTrigger){
            playerModel.layer = LayerMask.NameToLayer("Interior");
            dogModel.layer = LayerMask.NameToLayer("Interior");
        } else{
            playerModel.layer = LayerMask.NameToLayer("Default");
            dogModel.layer = LayerMask.NameToLayer("Default");
        }
    }
}

