using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GeneralGameManager : MonoBehaviour
{
    // Fix Clock puzzle highlights

    [SerializeField] Transform StartPosition;

    characterScript character;
    PlayerInteractor interactor;
    public CinemachineFreeLook LookCamera;
    public float originalCamSpeedY;
    public float originalCamSpeedX;

    // Start is called before the first frame update
    void Start()
    {
        SetToStartPosition();
        // get the components from the player
        character = GetComponent<characterScript>(); 
        interactor = GetComponent<PlayerInteractor>();

        // get original speed of the camera
        originalCamSpeedY = LookCamera.m_YAxis.m_MaxSpeed;
        originalCamSpeedX = LookCamera.m_XAxis.m_MaxSpeed;
    }


    void SetToStartPosition(){
        if(StartPosition){
            transform.position = StartPosition.position;
        }
    }

    public void EnablePlayer(){
        EnablePlayerMovement();
        EnablePlayerInteraction();
        EnableCameraMovement();
    }
    
    public void DisablePlayer(){
        DisablePlayerMovement();
        DisablePlayerInteraction();
        DisableCameraMovement();
    }

    void EnablePlayerMovement(){
        if(character != null){
            character.EnableMovement();
        }
    }

    void DisablePlayerMovement(){
        if(character != null){
            character.DisableMovement();
        }
    }

    // allow the player to interact with game objects and items
    void EnablePlayerInteraction(){
        if(interactor){
            interactor.SetCanInteract(true);
        }
    }
    // prevent the player from interacting with game objects and items
    void DisablePlayerInteraction(){
        if(interactor){
            interactor.SetCanInteract(false);
        }
    }

    // allow the player to move the camera 
    void EnableCameraMovement(){
        if(LookCamera){

            LookCamera.m_YAxis.m_MaxSpeed = originalCamSpeedY;

            LookCamera.m_XAxis.m_MaxSpeed = originalCamSpeedX;
        }
    }

    // don't allow the player to move the camera
    void DisableCameraMovement(){
        if(LookCamera){
            
            LookCamera.m_YAxis.m_MaxSpeed = 0;

            LookCamera.m_XAxis.m_MaxSpeed = 0;
        }
    }


    public void SetStartPosition(Transform NewPos){
        StartPosition = NewPos;
    }



}
