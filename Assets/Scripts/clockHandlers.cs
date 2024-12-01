using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class clockHandlers : MonoBehaviour
{
    public UnityEvent events;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // show an outline on the handler
    private void OnMouseEnter() {
        
    }

    // hide the outline on the handler
    private void OnMouseLeave() {

    }

    // run the function from the clock when the player clicks on the handler
    private void OnMouseDown() {
           
           events.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
