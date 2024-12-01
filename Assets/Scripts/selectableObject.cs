using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class selectableObject : MonoBehaviour
{
    public CinemachineVirtualCamera camera;
    public int highPriority = 15;
    public int lowPriority = 5;

    // focus on the parent component
    [ContextMenu("Set to Main")]
    public void setCameraMain(){
        camera.Priority = highPriority;
    }

    // back to players camera
    [ContextMenu("Set to Not Main")]
    public void setCameraOut(){
        camera.Priority = lowPriority;
    }
}
