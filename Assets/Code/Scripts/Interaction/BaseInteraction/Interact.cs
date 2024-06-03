using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interact : MonoBehaviour
{
    protected string triggerTag;

    [SerializeField] protected GameObject exclamationModel;

    private bool onTrigger;

    abstract protected void Init();

    private void Awake() {
        Init();
    }

    protected abstract void Action();
    protected abstract bool IsControllingActive();
    protected virtual void ConditionOnTrigger(){}

    private void Update() {
        if (onTrigger){
            if (SimpleInput.GetKeyDown(KeyCode.E)){
                Action();
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag(triggerTag)){
            if (!IsControllingActive()){
                exclamationModel.SetActive(false);
                onTrigger = false;
                return;
            } 

            onTrigger = true;

            exclamationModel.SetActive(true);

            ConditionOnTrigger();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag(triggerTag)){
            onTrigger = false;
            exclamationModel.SetActive(false);
        }
    }
}
