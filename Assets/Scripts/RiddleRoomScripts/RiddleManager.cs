using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleManager : MonoBehaviour
{

    [SerializeField] private OwlController Owl;
    // maximum number of player's tries
    public int MaxTries;

    // Make private later
    public int currentMistakesCount = 0;

    public int currentRiddle = 0;
    
    // the current riddle object, the player needs to find it
    private RiddleObject currentObject;

    // the name of the incorrect item to check for mistake
    public string IncorrectItemName;
    
    // list of Riddle objects in the game
    public List<RiddleObject> CorrectRiddleObjects;
    
    // list of Riddle dialogues for the room
    public List<DialogueTrigger> RiddleDialogues;

    [Header("Special Dialogues")]
    // dialogue to display when a correct one is picked 
    public DialogueTrigger onCorrectDialogue;

    // dialogue to display when an incorrect one is picked 
    public DialogueTrigger onIncorrectDialogue;

    // dialogue to display when the last one is picked 
    public DialogueTrigger LastDialogue;
    
    // dialogue to display when the player exceeds maximum tries 
    public DialogueTrigger AllWrongDialogue;


    // Start is called before the first frame update
    void Start()
    {
        if (CorrectRiddleObjects.Count != 0){
            AssignNextRiddle();
        }else{
            Debug.Log("List Should Not Be Empty. Error Arise");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AssignNextRiddle(){
        currentObject = CorrectRiddleObjects[currentRiddle];
    }
    public void AssignRiddleDialogue(){
        Owl.SetDialogue(RiddleDialogues[currentRiddle]);
    }

    public void checkRiddleObject(RiddleObject obj){
        
        // check if the object is correct:
        if(obj.getRiddleItemName() == currentObject.getRiddleItemName()){
            
            currentRiddle += 1;

            if (currentRiddle >= CorrectRiddleObjects.Count){
                
                // reached last puzzle
                LastDialogue.TriggerDialogue();

            }else{
                
                // proceed to the next riddle
                onCorrectDialogue.TriggerDialogue();
                
                AssignNextRiddle();
                AssignRiddleDialogue();
                
            }
        }else {
            
            currentMistakesCount += 1;
            if (currentMistakesCount > MaxTries){
                
                // restart the puzzle
                AllWrongDialogue.TriggerDialogue();

            }else{
                
                // resest current riddle
                onIncorrectDialogue.TriggerDialogue();
                
                AssignRiddleDialogue();
            }
        }
    }
}
