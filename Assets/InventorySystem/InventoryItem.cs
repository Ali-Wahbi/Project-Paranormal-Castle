using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "InventoryItem", order = 0)]
public class InventoryItem : ScriptableObject {
    public string ItemName;
    [TextArea(4, 8)]
    public string ItemDescription;

    public Sprite SmallIcon;
    public Sprite LargIcon;
    
    
}
