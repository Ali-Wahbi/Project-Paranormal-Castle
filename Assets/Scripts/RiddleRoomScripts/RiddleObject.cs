using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleObject : MonoBehaviour
{
    // the name of the item
    [SerializeField]
    private string ItemName;

    [SerializeField, TextArea(6,12)]
    private string ItemDescription;
    
    private void Start() {
        // if no name is provided, it defaults to incorrect, indicating wrong item
        if(ItemName == ""){
            ItemName = "incorrect";
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
}
