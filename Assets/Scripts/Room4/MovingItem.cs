using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovingItem : MonoBehaviour
{

    Vector3 startPos;
    Vector3 startScale;
    Quaternion startRot;
    [SerializeField] Transform secondPos;
    [SerializeField] bool UseScale = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startScale = transform.localScale;
        startRot = transform.rotation;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            goToSecondPos();
        }
        if(Input.GetKeyDown(KeyCode.N)){
            goToFirstPos();
        }
    }

    [ContextMenu("To first Pos")]
    public void goToFirstPos(){
        // Set position and rotation
        transform.position = startPos;
        transform.rotation = startRot;

        if (UseScale){
            transform.localScale = startScale;
        }
    }


    [ContextMenu("To second Pos")]
    public void goToSecondPos(){
        // Set position and rotation
        transform.position = secondPos.position;
        transform.rotation = secondPos.rotation;

        if (UseScale){
            transform.localScale = secondPos.localScale;
        }
    }
}
