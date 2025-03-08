using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
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

    public void SetIsEnabled(bool isEnabled){
        gameObject.SetActive(isEnabled);
    }
}
