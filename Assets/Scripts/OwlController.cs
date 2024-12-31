using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlController : MonoBehaviour
{
    public DialogueTrigger currentDialogue;
   
    public void StartDialogue(){
        currentDialogue.TriggerDialogue();
    }

    public void SetDialogue(DialogueTrigger dialogue){
        currentDialogue = dialogue;
        Debug.Log("Owl's currentDialogue changed.");
    }
}
