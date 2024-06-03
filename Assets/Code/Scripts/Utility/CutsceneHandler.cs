using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneHandler : MonoBehaviour
{
    public static CutsceneHandler sharedInstance;

    private void Awake() {
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }

    public void StartCutscene(PlayableDirector director){
        StartCoroutine(CutscenePlay(director));
    }

    private IEnumerator CutscenePlay(PlayableDirector director){
        PlayerController.sharedInstance.movementBlocked = true;
        DogController.sharedInstance.movementBlocked = true;
        CharacterChange.sharedInstance.changeBlocked = true;

        director.Play();

        while (director.state == PlayState.Playing) {
            yield return null;
        }

        PlayerController.sharedInstance.movementBlocked = false;
        DogController.sharedInstance.movementBlocked = false;
        CharacterChange.sharedInstance.changeBlocked = false;
    }
}
