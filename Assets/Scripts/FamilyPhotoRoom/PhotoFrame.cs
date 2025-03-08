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

        CheckSlices();
        Debug.Log("photoSlices size: " + photoSlices.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CheckSlices()
    {
        foreach (MovingSlice slice in photoSlices)
        {
            if (!slice.item)
            {
                return;
            }
            if (inventoryItems.Contains(slice.item.ItemName))
            {
                slice.gameObject.SetActive(true);
                Debug.Log("Activate Slice");
            }
            else
            {
                slice.gameObject.SetActive(false);
                Debug.Log("De-activate Slice");
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
