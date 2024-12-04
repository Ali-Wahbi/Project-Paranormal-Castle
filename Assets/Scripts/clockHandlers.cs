using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class clockHandlers : MonoBehaviour
{
    public UnityEvent events;
    Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    // show an outline on the handler
    private void OnMouseEnter() {
        if (outline!= null && !ClockHandlerSingleton.isActivated){
            outline.enabled = true;
        }
        
    }

    // hide the outline on the handler
    private void OnMouseExit() {
        
        if (outline!= null){
            outline.enabled = false;
        }

    }

    // run the function from the clock when the player clicks on the handler
    private void OnMouseDown() {
        if (!ClockHandlerSingleton.isActivated) {
            events.Invoke();
            doAnimation();
        }
    }

    void doAnimation(){
        StartCoroutine(AnimationUpDown());
    }

    private IEnumerator AnimationUpDown(){
        ClockHandlerSingleton.isActivated = true;
        outline.enabled = false;

        float startPosition = transform.position.y;
        float tempPosition = startPosition;
        float endPosition = startPosition - 0.25f;


        // from temp -> end 
       while(tempPosition >= endPosition){
            transform.position = new Vector3(transform.position.x, tempPosition, transform.position.z);
            tempPosition -= 0.01f;
            yield return new WaitForSeconds(0.01f);
       }
    

        // then temp -> start
        while(tempPosition <= startPosition){
            transform.position = new Vector3(transform.position.x, tempPosition, transform.position.z);
            tempPosition += 0.01f;
            yield return new WaitForSeconds(0.01f);
       }
       
        ClockHandlerSingleton.isActivated = false;
    }

}
