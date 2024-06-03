using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BonePuzzleEvent : MonoBehaviour
{
    public static BonePuzzleEvent sharedInstance;

    [SerializeField] private GameObject bonePuzzle;
    [SerializeField] private Item boneItem;
    [HideInInspector] public bool bonePuzzleInProgress;

    [HideInInspector] public int bonesThrowed;
    [SerializeField] private int bonesThrowedToEnd;

    [SerializeField] private PlayableDirector cutscene_0;
    private bool cutscenePlayed;

    private void Awake() {
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }

    private void Update() {
        // Si coges el hueso que hay en el suelo comienza el evento
        if (PlayerInventoryManager.sharedInstance.HasItem(boneItem) && !bonePuzzleInProgress){
            bonePuzzleInProgress = true;
            bonePuzzle.SetActive(true);
        }

        if (!bonePuzzleInProgress) return;

        if(bonesThrowed == 2 && !cutscenePlayed){
            cutscenePlayed = true;
            Invoke("PlayCutscene", 1.5f);
        }

        // Bone Puzzle ended
        if(bonesThrowed == bonesThrowedToEnd && bonePuzzleInProgress){
            bonePuzzleInProgress = false;
            Invoke("EndPuzzle", 2f);
        }

        // Player cannot move while doing the puzzle
        if (bonePuzzleInProgress && BonePuzzleEvent.sharedInstance.bonesThrowed > 0){
            PlayerController.sharedInstance.movementBlocked = true;
        } 
    }

    void EndPuzzle(){
        Destroy(GameObject.Find("DynamicObjects").transform.GetChild(0).gameObject);
        bonePuzzle.SetActive(false);
        Destroy(gameObject);
    }

    void PlayCutscene(){
            CutsceneHandler.sharedInstance.StartCutscene(cutscene_0);
    }
}
