using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleObject : MonoBehaviour
{
    // the name of the item
    [SerializeField]
    private string ItemName;

    // The corresponding item of the object, makes accessing the name and description easier
    [SerializeField] RiddleObjectItem Item; 
    
    // the start position of the riddle object
    public Vector3 StartPosition;

    // the end position of the riddle object after it is correctly solved
    [SerializeField] Transform FinalPosition;

    private void Start() {
        // if no name is provided, it defaults to incorrect, indicating wrong item
        if(Item.ItemName == ""){
            ItemName = "incorrect";
        } else {
            ItemName = Item.ItemName;
        }
        Interactable interactable = gameObject.GetComponent<Interactable>();
        if(interactable != null){
            interactable.interactWord = "Take " + ItemName;
        }

        StartPosition = transform.position;
    }

    [ContextMenu("Get Name")]
    public string getRiddleItemName(){
        Debug.Log("Got item: " + ItemName);
        return ItemName;
    }

    public string getRiddleItemDescription(){
        return Item.ItemDescription;
    }

    [ContextMenu("GetToStartPos")]
    public void GetToStartPos(){
        transform.position = StartPosition;
    }


    [ContextMenu("GetToEndPos")]
    public void GetToEndPos(){
        if (FinalPosition.position != Vector3.zero){
            transform.position = FinalPosition.position;
        }
    }
}
