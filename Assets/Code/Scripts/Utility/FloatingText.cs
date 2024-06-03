using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TMP_Text floatingText;

    public void Show(){
        if(!floatingText.isActiveAndEnabled){
            StartCoroutine("ShowTimer");
        }
    }

    private IEnumerator ShowTimer(){
        floatingText.enabled = true;
        yield return new WaitForSeconds(2);
        floatingText.enabled = false;
    }
}
