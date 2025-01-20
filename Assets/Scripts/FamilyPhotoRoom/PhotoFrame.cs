using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PhotoFrame : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private CinemachineVirtualCamera FoucusCamera;
    [SerializeField] private int HighPriority;
    [SerializeField] private int LowPriority;

    [Header("Required Inventory Items")]
    [SerializeField, Tooltip("Slices to show or hide")]
    private List<MovingSlice> photoSlices;
    [SerializeField] private InventoryManager inventory;
    List<string> inventoryItems;

    // Start is called before the first frame update
    void Start()
    {
        inventoryItems = inventory.GetItemNames();
        Debug.Log("item names: " + inventoryItems.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CheckSlices()
    {
        foreach (MovingSlice slice in photoSlices)
        {

            if (slice.item && inventoryItems.Contains(slice.item.ItemName))
            {
                slice.GetComponent<GameObject>().SetActive(true);
            }
            else
            {
                slice.GetComponent<GameObject>().SetActive(false);
            }

        }
    }
    #region Camera
    public void SetCameraMain()
    {
        SetCameraPriority(HighPriority);
    }

    public void SetCameraAside()
    {
        SetCameraPriority(LowPriority);
    }

    void SetCameraPriority(int priority)
    {
        FoucusCamera.Priority = priority;
    }
    #endregion
}
