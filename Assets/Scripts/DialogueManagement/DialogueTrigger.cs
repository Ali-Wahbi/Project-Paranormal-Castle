using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManager MainDm; 

    public Dialogue dialogue;

    [ContextMenu("Start Dialogue")]
    public void TriggerDialogue(){
        if(MainDm!=null){
            MainDm.StartDialogue(dialogue);
        }
    } 
}
