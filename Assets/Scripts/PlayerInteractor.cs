using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    // Interactor is attached to the player
    //  when the player gets close to an interactable object, the following should appear
    // hihglights on the interactable object (outline)
    // the word (#interact)(E) appears  
    
    public float playerReach = 3f;
    Interactable currentInteractable;

    public bool canInteract = true;
    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null){
            currentInteractable.Interact();
        }
    }

    void CheckInteraction(){
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out hit, playerReach)){
                if (hit.collider.tag == "Interactable" && canInteract){
                    
                    Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                    if (currentInteractable && newInteractable != currentInteractable){
                        DisableCurrentInteractable();
                    }

                    if (newInteractable && newInteractable.enabled){
                        // Debug.Log("Found Interactable");
                        SetNewCurrentInteractable(newInteractable);
                    }
                    else // the interactable is not enabled
                    {
                        DisableCurrentInteractable();
                    }
                }
                else //the object is not interactable
                {
                   DisableCurrentInteractable();
                }
            }
            else // ray cast hit nothing
            {
                DisableCurrentInteractable();
            }
    }

    void SetNewCurrentInteractable(Interactable interactable){
        currentInteractable = interactable;
        currentInteractable.EnableOutline();
        HudController.instance.EnableInteractionText(currentInteractable.interactWord, currentInteractable.interactionColor);
        
    }
    void DisableCurrentInteractable(){
        HudController.instance.DisableInteractionText();
        if (currentInteractable){
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }

    public void SetCanInteract(bool newState){
        canInteract = newState;
    }
}
