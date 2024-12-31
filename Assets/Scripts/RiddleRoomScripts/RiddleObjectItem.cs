using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Riddle Item", menuName = "Item/Riddle Item", order = 0)]
public class RiddleObjectItem : ScriptableObject {
    public string ItemName;

    [TextArea(6,3)]
    public string ItemDescription;
}