using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    [SerializeField] bool UseIndex = true;
    [SerializeField] int NextRoomIndex;
    [SerializeField] string NextRoomName;

    [SerializeField] InventoryItem RequiredItem;
    [SerializeField] InventoryManager MainInventory;

    public void GotToNextRoom(){

        if (RequiredItem && MainInventory){
            List<string> itemsNames = MainInventory.GetItemNames();
            // the required item is specified
            if (itemsNames.Contains(RequiredItem.ItemName)){
                // the player has the required item
                GoToRoom();
            } else {
                // the player does not have the required item
                Debug.LogError("Dont have Required Item : " + RequiredItem.ItemName + ".");
            }
        } else {
            // no required item specified
            GoToRoom();
        }
    }

    // Go to the specified room 
    void GoToRoom(){
        if (UseIndex){
            SceneManager.LoadScene(NextRoomIndex);
        } else {
            SceneManager.LoadScene(NextRoomName);
        }
    }


}
