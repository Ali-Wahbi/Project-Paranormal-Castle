using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncorrectItemsHandler : MonoBehaviour
{
    public void DisableChildrenInteraction(){
        // Debug.Log("Disable all children");
        foreach (Transform item in transform)
        {
            item.tag = "Untagged";
        }
    }

}
