using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockPointer : MonoBehaviour
{


    // increase or decrease the angle of the pointer, by passing 1 or -1
    public void setAngle(int newDirection){
        StartCoroutine(rotationAnimation(newDirection));
    }

    private IEnumerator rotationAnimation(int newDirection){
        float newAngle = newDirection;
        Debug.Log("angle = " + newAngle);

        // transform.rotation = new Vector3(0, 0, newAngle);
        Vector3 rotate = new Vector3(0, 0, -newAngle);

        for (int i = 0; i < 30; i++)
        {
            transform.Rotate(rotate);
            yield return new WaitForSeconds(0.01f * 5/3);
            
        }
    }

}
