using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPendulumAnim : MonoBehaviour
{
    
    public int rotationSize = 7;
    float magnitude = 0.038f ;
    float speed = 0.08f;
    float waitAfter = 0.15f;
    public float currentSpeed = 0;

    void Start(){
    }

    [ContextMenu("Start Pend Anim")]
    public void StartAnim(){
        StartCoroutine(DoAnimation());
    }

    IEnumerator MoveToStartPosition(int newDirection){
        Vector3 rotate = new Vector3(0, 0, newDirection);
        for (int i = 0; i < rotationSize; i++)
        {
            transform.Rotate(rotate);
            currentSpeed = magnitude* Mathf.Cos(i*speed);
            yield return new WaitForSeconds(currentSpeed);
        }
    }
    public IEnumerator DoAnimation(){
        Debug.Log("Pendul Rotation start");
        yield return MoveToStartPosition(1);
        while(true){
            
            yield return new WaitForSeconds(waitAfter);

            yield return MoveToStartPosition(-1);
            yield return MoveToStartPosition(-1);
            
            yield return new WaitForSeconds(waitAfter);

            yield return MoveToStartPosition(1);
            yield return MoveToStartPosition(1);
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
        yield return new WaitForSeconds(0.01f);
    }
    IEnumerator MoveFromEndToStart(){
        yield return new WaitForSeconds(0.01f);
    }
}
