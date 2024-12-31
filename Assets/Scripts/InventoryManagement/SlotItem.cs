using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlotItem : MonoBehaviour
{
    public Image ItemImage;
    public InventoryItem _item;
    // Start is called before the first frame update
    void Start()
    {
        // ItemImage = GetComponent<Image>();
        setSlotItem(_item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSlotItem(InventoryItem item){
        // Debug.Log("setSlotItem");
        _item = item;
        ItemImage.sprite = item.SmallIcon;
        // Debug.Log("Slot has new Item");
    }

    public InventoryItem getSlotItem(){
        // Debug.Log("get Item from new Slot");
        return _item;
    }

    [ContextMenu("Debug")]
    public void DebugSlot(){
        var x = gameObject.GetComponentInParent<InventorySlotManager>().GetComponentInParent<InventoryManager>();
        Debug.Log(x);

    }

    public void onSlotClicked(){
        InventorySlotManager ism = gameObject.GetComponentInParent<InventorySlotManager>();
        InventoryManager im = ism.GetComponentInParent<InventoryManager>();

        im.setCurrentItem(_item);
        Debug.Log("Slot Clicked");
    }
}

