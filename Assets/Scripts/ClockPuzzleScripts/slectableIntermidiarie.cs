using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slectableIntermidiarie : MonoBehaviour
{
    private selectableObject focusedObject;

    public void focusOnObject(selectableObject selectObj){
        focusedObject = selectObj;
    }

    public void focusOffObject(){
        if (focusedObject != null){
            focusedObject.setCameraOut();
            focusedObject = null;
        }
    }
}
