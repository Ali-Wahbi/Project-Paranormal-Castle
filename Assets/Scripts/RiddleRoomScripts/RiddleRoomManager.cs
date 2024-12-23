using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleRoomManager : MonoBehaviour
{
    
    [SerializeField] List<Collectable> collectables;
    [SerializeField] List<RiddleObject> riddleObjects;

    private void Start() {
        disableAllInteracatables();
    }

    [ContextMenu("Enable All")]
    public void enableAllInteracatables(){
        enableCollectables();
        enableRiddleObjects();
    }

    [ContextMenu("Disable All")]
    public void disableAllInteracatables(){
        disableCollectables();
        disableRiddleObjects();
    }

    void enableCollectables(){
        foreach (Collectable collectable in collectables)
        {
            Interactable interact = collectable.GetComponent<Interactable>();
            interact.enabled = true;
        }
    }
    void disableCollectables(){
        foreach (Collectable collectable in collectables)
        {
            Interactable interact = collectable.GetComponent<Interactable>();
            interact.enabled = false;
            
            Outline outline = collectable.GetComponent<Outline>();
            if (outline != null){
                outline.enabled = false;
            }
        }
    }

    void enableRiddleObjects(){
        foreach (RiddleObject objects in riddleObjects)
        {
            Interactable interact = objects.GetComponent<Interactable>();
            interact.enabled = true;
        }
    }

    void disableRiddleObjects(){
        foreach (RiddleObject objects in riddleObjects)
        {
            Interactable interact = objects.GetComponent<Interactable>();
            interact.enabled = false;

            Outline outline = objects.GetComponent<Outline>();
            if (outline != null){
                outline.enabled = false;
            }
        }
    }
}
