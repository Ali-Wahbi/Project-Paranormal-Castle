using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    // every Interactable object should have: 
    // func Invoke(): happens when the player interacts
    // interaction word: appears beside the letter (E) 

    public string interactWord;

    [SerializeField]
    private UnityEvent onInteraction; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
