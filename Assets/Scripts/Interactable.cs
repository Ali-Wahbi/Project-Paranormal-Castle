using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public class Interactable : MonoBehaviour
{
    // every Interactable object should have: 
    // func Invoke(): happens when the player interacts
    // interaction word: appears beside the letter (E) 

    Outline outline;
    public string interactWord;
    [SerializeField] public Color interactionColor = Color.white;

    [SerializeField]
    private UnityEvent onInteraction; 

    private void Reset() {
        transform.tag = "Interactable";
    }
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

   [ContextMenu("Interact")]
   public void Interact(){
        onInteraction.Invoke();
   }

    public void DisableOutline(){
        // If the Outline exists
        if (outline){
            outline.enabled = false;
        }
    }
    
    public void EnableOutline(){
        // If the Outline exists
        if (outline){
            outline.enabled = true;
        }
    }
}
