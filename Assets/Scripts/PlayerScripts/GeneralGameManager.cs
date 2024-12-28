using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralGameManager : MonoBehaviour
{

    [SerializeField] Transform StartPosition;

    characterScript character;
    // Start is called before the first frame update
    void Start()
    {
        // SetToStartPosition();
        character = GetComponent<characterScript>(); 
    }


    void SetToStartPosition(){
        if(StartPosition){
            transform.position = StartPosition.position;
        }
    }

    public void EnablePlayerMovement(){
        if(character != null){
            character.EnableMovement();
        }
    }

    public void DisablePlayerMovement(){
        if(character != null){
            character.DisableMovement();
        }
    }

    public void SetStartPosition(Transform NewPos){
        StartPosition = NewPos;
    }
}
