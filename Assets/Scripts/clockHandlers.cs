using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class clockHandlers : MonoBehaviour
{
    public UnityEvent events;
    Outline outline;

    // dont allow the handles to be used if the clock is already solved
    private bool isClockSolved = false;

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public void SetClockSolved(){
        isClockSolved = true;
    }

    // show an outline on the handler
    private void OnMouseEnter() {
        Debug.Log("MOUSE ENTERED");
        if (outline!= null && !ClockHandlerSingleton.isActivated && !isClockSolved){
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
    [ContextMenu("Click Handler")]
    private void OnMouseDown() {
        if (!ClockHandlerSingleton.isActivated && !isClockSolved) {
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


        // from temp -> end , move down
       while(tempPosition >= endPosition){
            transform.position = new Vector3(transform.position.x, tempPosition, transform.position.z);
            tempPosition -= 0.01f;
            yield return new WaitForSeconds(0.01f);
       }
    

        // then temp -> start , move up
        while(tempPosition <= startPosition){
            transform.position = new Vector3(transform.position.x, tempPosition, transform.position.z);
            tempPosition += 0.01f;
            yield return new WaitForSeconds(0.01f);
       }
       
        ClockHandlerSingleton.isActivated = false;
    }

}
