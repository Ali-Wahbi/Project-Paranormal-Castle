using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

   
   public void Interact(){
        onInteraction.Invoke();
   }

    public void DisableOutline(){
        outline.enabled = false;
    }
    
    public void EnableOutline(){
        outline.enabled = true;
    }
}