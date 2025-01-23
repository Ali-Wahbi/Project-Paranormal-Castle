using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetChildrenColliders(false);
    }

    // Update is called once per frame
    void Update()
    {

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
