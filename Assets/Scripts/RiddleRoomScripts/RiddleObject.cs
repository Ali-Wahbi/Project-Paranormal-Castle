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
    }

    [ContextMenu("Get Name")]
    public string getRiddleItemName(){
        Debug.Log("Got item: " + ItemName);
        return ItemName;
    }

    public string getRiddleItemDescription(){
        return Item.ItemDescription;
    }
}
