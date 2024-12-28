using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    // get a list of all the collectables in the level
    // load all the items from the inventory system

    public List<Collectable> LevelCollectables;
    public void LoadInventoryItems(List<InventoryItem> inventoryItems){
        Debug.Log("Disabling collectable");
        foreach(Collectable collItem in LevelCollectables){
            if (inventoryItems.Contains(collItem.getInventoryItem())){
                collItem.SetIsEnabled(false);
            }
        }
    }
    
}
