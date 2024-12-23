using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private InventoryItem ObjectItem;

    public InventoryItem getInventoryItem(){
        // Debug.Log("Item collected");
        // Destroy the object after collecting
        return ObjectItem;
    }

    private void Start() {
        Interactable interactable = gameObject.GetComponent<Interactable>();
        if(interactable != null){
            interactable.interactWord = "Collect " + ObjectItem.ItemName;
        }
    }
}
