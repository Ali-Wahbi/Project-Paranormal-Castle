using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicesManager : MonoBehaviour
{
    void Start()
    {
        SetChildrenColliders(false);
    }

    // Test this function
    public void SetChildrenColliders(bool active)
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<BoxCollider>().enabled = active;
        }
    }
}
