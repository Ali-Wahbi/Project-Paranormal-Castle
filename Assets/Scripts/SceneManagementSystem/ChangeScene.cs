using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Interactable))]
public class ChangeScene : MonoBehaviour
{

    [SerializeField] bool UseIndex = true;
    [SerializeField] int NextRoomIndex;
    [SerializeField] string NextRoomName;

    [SerializeField] InventoryItem RequiredItem;
    [SerializeField] InventoryManager MainInventory;
    [SerializeField] GameObject lockedPopUp;
    DoorRotator dr;
    // to prevent multiple scene changes at once
    bool isGoingToNextRoom = false;
    private void Start()
    {
        dr = GetComponent<DoorRotator>();
    }

    public void GotToNextRoom()
    {

        if (RequiredItem && MainInventory)
        {
            List<string> itemsNames = MainInventory.GetItemNames();
            // the required item is specified
            if (itemsNames.Contains(RequiredItem.ItemName))
            {
                // the player has the required item
                ChangeRoom();
            }
            else
            {
                // the player does not have the required item
                InstantiatePopUp();
                // Debug.LogError("Dont have Required Item : " + RequiredItem.ItemName + ".");
            }
        }
        else
        {
            // no required item specified
            ChangeRoom();
        }
    }

    // Go to the specified room 
    void ChangeRoom()
    {

        if (isGoingToNextRoom) return;
        isGoingToNextRoom = true;
        // Play Fade Animation
        OpenDoor();
        StartCoroutine(ChangeRoomWait());


    }

    // Go to the specified room
    void GotoRoom()
    {
        if (UseIndex)
            SceneManager.LoadScene(NextRoomIndex);
        else
            SceneManager.LoadScene(NextRoomName);
    }

    // Instantiate the locked pop up if no key is found
    void InstantiatePopUp()
    {
        GameObject go = Instantiate(lockedPopUp);
        Destroy(go, 3f);
    }

    // Open the door with animation and sound
    void OpenDoor()
    {
        if (dr) dr.RotateDoor();
    }

    // Wait for the door to open then go to the next room
    IEnumerator ChangeRoomWait()
    {
        yield return new WaitForSeconds(2f);
        GotoRoom();
    }


}
