using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleObject : MonoBehaviour
{
    // the name of the item
    [SerializeField]
    private string ItemName;
    
    private void Start() {
        // if no name is provided, it defaults to incorrect, indicating wrong item
        if(ItemName == ""){
            ItemName = "incorrect";
        }
    }

    [ContextMenu("Get Name")]
    public string getRiddleItemName(){
        Debug.Log("Got item: " + ItemName);
        return ItemName;
    }
}
