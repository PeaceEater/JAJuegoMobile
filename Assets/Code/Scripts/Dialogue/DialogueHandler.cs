using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Febucci.UI;

public class DialogueHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueBox;
    [SerializeField] private TypewriterByCharacter typewriter;
    [SerializeField] private DialogueBlock dialogueBlock;

    private bool textLineEnded;

    private void Start() {
        dialogueBox.enabled = false;
        typewriter.onTextShowed.AddListener(HandleTextLineEndedEvent);
        //StartCoroutine(ShowDialogue(dialogueBlock));
    }

    public IEnumerator ShowDialogue(DialogueBlock dialogueBlock){
        dialogueBox.enabled = true;
        PlayerController.sharedInstance.movementBlocked = true;
        DogController.sharedInstance.movementBlocked = true;
        CharacterChange.sharedInstance.changeBlocked = true;

        for (int i = 0; i < dialogueBlock.textLine.Length; i++)
        {
            dialogueBox.text = dialogueBlock.textLine[i];
            while (true)
            {
                if (SimpleInput.GetKeyDown(KeyCode.E)){
                    if(textLineEnded) {
                        break;
                    } else {
                        typewriter.SkipTypewriter();
                    }
                } 
                yield return null;
            }

            textLineEnded = false;

            yield return null;
        }
        dialogueBox.enabled = false;
        PlayerController.sharedInstance.movementBlocked = false;
        DogController.sharedInstance.movementBlocked = false;
        CharacterChange.sharedInstance.changeBlocked = false;
    }

    private void HandleTextLineEndedEvent()
    {
        textLineEnded = true;
    }
    
}
