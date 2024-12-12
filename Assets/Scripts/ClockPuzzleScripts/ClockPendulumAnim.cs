using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPendulumAnim : MonoBehaviour
{
    
    public int rotationSize = 7;
    public float magnitude = 0.038f ;
    public float speed = 0.048f;
    public float waitAfter = 0.15f;
    public float currentSpeed = 0;

    void Start(){
        for (int i = 1; i <= 16; i++)
        {
            float cureent = magnitude * Mathf.Sin(i*speed);
            Debug.Log($"at i = {i} : {cureent}");
        }
    }

    [ContextMenu("Start Pend Anim")]
    public void StartAnim(){
        StartCoroutine(DoAnimation());
    }

    IEnumerator MoveToStartPosition(){
        Vector3 rotate = new Vector3(0, 0, 1);
        for (int i = 0; i < rotationSize; i++)
        {
            transform.Rotate(rotate);
            currentSpeed = magnitude* Mathf.Sin(i*speed);
            yield return new WaitForSeconds(currentSpeed);
        }
    }
    public IEnumerator DoAnimation(){
        Debug.Log("Pendul Rotation start");
        yield return MoveToStartPosition();
        while(true){
            
            // yield return new WaitForSeconds(waitAfter);
            yield return MoveFromStartToEnd();
            
            // yield return new WaitForSeconds(waitAfter);
            yield return MoveFromEndToStart();
        }
        // FullRotation();
        // yield return new WaitForSeconds(0.01f);
    }

    public IEnumerator FullRotation(){
        MoveFromStartToEnd();
        MoveFromEndToStart();
        yield return new WaitForSeconds(0.01f);
    }

    IEnumerator MoveFromStartToEnd(){
         Vector3 rotate = new Vector3(0, 0, -1);
        for (int i = 0; i < rotationSize*2; i++)
        {
            currentSpeed = magnitude* Mathf.Sin(i*speed);
            yield return new WaitForSeconds(currentSpeed);
            transform.Rotate(rotate);
        }
    }
    IEnumerator MoveFromEndToStart(){
         Vector3 rotate = new Vector3(0, 0, 1);
        for (int i = 0; i < rotationSize*2; i++)
        {
            transform.Rotate(rotate);
            currentSpeed = magnitude* Mathf.Sin(i*speed);
            yield return new WaitForSeconds(currentSpeed);
        }
    }
}
