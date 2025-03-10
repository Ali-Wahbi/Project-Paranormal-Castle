using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class CubePlayer : MonoBehaviour
{   
    

    public GameObject cube;

    public float MoveVector = 1;
    public float RotateAngle = 90;

    Vector3 MoveVertical;
    Vector3 MoveHorizontal;

    Vector3 RotateVertical;
    Vector3 RotateHorizontal;

    public bool canMove = true;

    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {   
        MoveVector = transform.localScale.x;
        // add => up , subtract => down
        MoveVertical    =  new Vector3(0, 0, MoveVector);
        // add => right , subtract => left
        MoveHorizontal  =  new Vector3(MoveVector, 0, 0);

        // add => up , subtract => down
        RotateVertical = new Vector3(RotateAngle, 0, 0);
        // add => left , subtract => right
        RotateHorizontal = new Vector3(0, 0, RotateAngle);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        
        if (canMove)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                
                MovePos(MoveVertical);
                
                RotateCube(RotateVertical);

                // transform.position += MoveVertical;
            }
            if(Input.GetKeyDown(KeyCode.DownArrow)){
                
                MovePos(-MoveVertical);

                RotateCube(-RotateVertical);
                // transform.position -= MoveVertical;
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                
                MovePos(MoveHorizontal);
                
                RotateCube(-RotateHorizontal);
                // transform.position += MoveHorizontal;
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                
                MovePos(-MoveHorizontal);
                
                RotateCube(RotateHorizontal);
                // transform.position -= MoveHorizontal;
            }
        }

    }

    void MovePos(Vector3 moveDir){
        canMove = false;
        StartCoroutine(CubeMoving(moveDir));
        // transform.position += moveDir;


    }

    void RotateCube(Vector3 rotateDir){
        canMove = false;
        StartCoroutine(CubeRotation(rotateDir));
        

    }

    IEnumerator CubeMoving(Vector3 moveDir){
        float time = 8f;

        for (int i = 0; i < time; i++)
        {
            transform.position += moveDir/time;
            yield return new WaitForSeconds(0.1f/time);
        }

        rb.isKinematic = false;


    }

    

    IEnumerator CubeRotation(Vector3 rotateDir){
        // Debug.Log(rotateDir.magnitude);
        float rotateLength = rotateDir.magnitude;
        float time = 4f;

        for (int i = 0; i < time*2; i++)
        {
            cube.transform.Rotate(rotateDir/(time*2), Space.World);
            yield return new WaitForSeconds(0.1f/(time*2));
        }
    }

    public void FloorSide(Sides side){
        // Debug.Log("At floor is side: " + side);

        canMove = true;
        rb.isKinematic = true;
    }
}
public enum Sides{
        UP, DOWN, LEFT, RIGHT, FRONT, BACK
    }