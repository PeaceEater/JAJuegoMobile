using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialgoue", menuName = "Dialogue/Create New Dialogue")]
public class DialogueBlock : ScriptableObject
{
    [TextArea(5,10)]
    public string[] textLine;
}
