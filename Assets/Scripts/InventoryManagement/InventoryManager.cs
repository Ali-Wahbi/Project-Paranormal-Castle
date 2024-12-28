using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    // inventory manager:
    // loads all items into screen 
    // update the text in the inventory ui when a slot is clicked
    // 

    [SerializeField] private InventorySlotManager slotManager;
    [SerializeField] private CollectablesManager CollectManager;
    [SerializeField] private GeneralGameManager GameManager;
    [SerializeField] private Animator anim;

    [Header("Ui Elements")]
    public TMP_Text ItemName;
    public TMP_Text ItemDescription;

    public Image itemImage;
    
    //remove exampleItem later
    public InventoryItem exampleItem;

    //remove public later
    public List<InventoryItem> _inventory;
    public InventoryItem _currentSelected;


    bool _isShown = false;

    private void Awake() {
        // AddItemToInventory(exampleItem);
        // refreshSlotInventory();
        LoadInventory();
    }

    private void OnDestroy() {
        SaveInventory();
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
        // Debug.Log("Item clicked");
        LoadInventory();
        // ClearInventory();
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

    string fullPath = Application.dataPath + "/Saves/";
    string fileName = "InvSave.txt";
    
    void CheckFileDir(){
        if(!Directory.Exists(fullPath)){
            Directory.CreateDirectory(fullPath);
        }
    }
    public void SaveInventory(){
        // get all of the items names from the inventory using GetItemNames() and save it to a file
        InventorySaver saver = new InventorySaver {
            InvItems = GetItemNames()
        };
        string saveString = JsonUtility.ToJson(saver);
        Debug.Log("Save Items: " + saveString);

        CheckFileDir();
        File.WriteAllText(fullPath + fileName, saveString);
    }

    void LoadInventory(){
        // get all of the items names from the save, 
        // then get a list of all of the items in the game from the Items folder,
        // then add the items to the inventory 
        
        // first clear all items from the inventory 
        ClearInventory();

        if (File.Exists(fullPath + fileName)){

            // load the data from the file    
            string loadString = File.ReadAllText(fullPath + fileName);
            Debug.Log("Load Items: " + loadString);
            InventorySaver InvLoad = JsonUtility.FromJson<InventorySaver>(loadString);


            // create lists of items and items name
            List<InventoryItem> AllItems = new();
            List<string> AllItemsNames = new();

            // fill the lists using func GetAllItemNames and add explicit casting
            foreach (InventoryItem item in GetAllItemNames().Cast<InventoryItem>())
            {
                AllItems.Add(item);
                AllItemsNames.Add(item.ItemName);
            }
            // use this method to insure items are loaded in the order they were collected, not alphabetically
            // loop through the loaded items names
            foreach(string itName in InvLoad.InvItems)
            {   
                // find the index of the item
                int index = AllItemsNames.IndexOf(itName);

                if (index != -1){
                    // Debug.Log("Found Item at index :" + index);
                    // add the item to the inventory
                    _inventory.Add(AllItems[index]);
                } else{
                    // rise an error
                    Debug.LogError("Index returns -1");
                }
            }
            // refresh the slots in the inventory UI
            refreshSlotInventory();
            if(CollectManager){
                CollectManager.LoadInventoryItems(_inventory);
            }
        }
    }

    void ClearInventory(){
        _inventory.Clear();

        Debug.Log("Inventory Cleared");
    }

    Object[] GetAllItemNames(){
        return Resources.LoadAll("Items/");
    }

    public struct InventorySaver{
        public List<string> InvItems;
    }
}