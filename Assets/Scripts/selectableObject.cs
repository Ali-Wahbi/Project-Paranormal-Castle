using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class selectableObject : MonoBehaviour
{
    public CinemachineVirtualCamera objectCamera;

    public int highPriority = 15;
    public int lowPriority = 5;
    

    public UnityEvent onFocusedEvents;
    public UnityEvent onOutFocusedEvents;

    // focus on the parent component
    [ContextMenu("Set to Main")]
    public void setCameraMain(){
        objectCamera.Priority = highPriority;
        onFocusedEvents.Invoke();

    }

    // back to players camera
    [ContextMenu("Set to Not Main")]
    public void setCameraOut(){
        objectCamera.Priority = lowPriority;
        onOutFocusedEvents.Invoke();
        
    }
}
