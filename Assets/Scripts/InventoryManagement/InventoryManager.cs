using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    // inventory manager:
    // loads all items into screen 
    // update the text in the inventory ui when a slot is clicked
    // 

    [SerializeField] private InventorySlotManager slotManager;
    [SerializeField] private GeneralGameManager GameManager;
    [SerializeField] private Animator anim;

    public TMP_Text ItemName;
    public TMP_Text ItemDescription;

    public Image itemImage;
    
    //remove exampleItem later
    public InventoryItem exampleItem;

    //remove public later
    public List<InventoryItem> _inventory;
    public InventoryItem _currentSelected;


    bool _isShown = false;

    private void Start() {
        AddItemToInventory(exampleItem);
        refreshSlotInventory();
    }

    private void Update() {
        // click on inventory Button
        if(Input.GetKeyUp(KeyCode.I)){
            if(_isShown){
                GameManager.EnablePlayerMovement();
                hideInventory();
            } else {
                GameManager.DisablePlayerMovement();
                showInventory();

                // GetItemNames();
            }
        }
    }

    [ContextMenu("Debug")]
    public void DebugInventory(){
        Debug.Log("Item clicked");
    }

    public void setCurrentItem(InventoryItem item){
        // InventoryItem item = slotItem.getSlotItem();
        if(_currentSelected != item){
        Debug.Log("SetCurrentItem is called");
            ItemName.text = item.ItemName;

            // ItemDescription.text = item.ItemDescription;

            StopAllCoroutines();
            // display the text character by character instead of instantly
            StartCoroutine(TypeSentence(item.ItemDescription));

            itemImage.sprite = item.LargIcon;

            _currentSelected = item;
        }
    }

    IEnumerator TypeSentence(string sentence){
        ItemDescription.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            ItemDescription.text += letter;
            yield return null;
        }
    }

    void showInventory(){
        
        // enter the inventory if it is not open
        anim.SetTrigger("enterAnim");
        _isShown = true;


        // set the _currentSelected item to the first item
        // if (_currentSelected == null){
        //     _currentSelected = _inventory[0];
        // }
    }

    void hideInventory(){
        // play hide animation
        // exit the inventory if it is open
        anim.SetTrigger("exitAnim");
        _isShown = false;

    }

    public void AddItemToInventory(InventoryItem item){
        _inventory.Add(item);
        slotManager.AddItem(item);
    }

    // TODO finish after creating collectable, storable object script 
    public void AddItemFromCollectable(Collectable collectable){
        InventoryItem item = collectable.getInventoryItem();
     
        // Debug.Log("Got Item: " + item.ItemName);
        AddItemToInventory(item);
    }

    void refreshSlotInventory(){
        slotManager.ClearChildren();
        foreach (InventoryItem item in _inventory){
            slotManager.AddItem(item);
            // Debug.Log("Slot manager added child");
        }
    }

    public void removeItem(InventoryItem item){
        if (_currentSelected == item){
            _currentSelected = null;
        }
        _inventory.Remove(item);
    }

    public List<string> GetItemNames(){
        List<string> names = new List<string>();

        foreach (InventoryItem item in _inventory)
        {
            names.Add(item.ItemName);
        }
        // Debug.Log("Names Are: " + string.Join(" ", names));

        return names;
    }

    void SaveInventory(){
        // get all of the items names from the inventory using GetItemNames() and save it to a file
    }

    void LoadInventory(){
        // get all of the items names from the save, 
        // then get a list of all of the items in the game from the Items folder,
        // then add the items to the inventory 
    }

}
