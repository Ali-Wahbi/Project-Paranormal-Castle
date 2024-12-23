using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InventorySlotManager : MonoBehaviour
{
    [SerializeField] private SlotItem InventorySlot;
    // public UnityEvent SlotClickedEvents;

    // [ContextMenu("Add Slot")]
    public void AddItem(InventoryItem item){
        // 
        // InventoryItem item = InventoryItem.CreateInstance("InventoryItem");
        var newSlot = Instantiate(InventorySlot, this.transform);
        
        newSlot.setSlotItem(item);
        
        
    }

    public void DebugInventoryManager(){
        Debug.Log("Item slot clicked");
    }

    //TODO: clear all of the elements from the InventorySlotManager
    [ContextMenu("Dubug Clear")]
    public void ClearChildren(){
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
    private void Start() {
    }
}
