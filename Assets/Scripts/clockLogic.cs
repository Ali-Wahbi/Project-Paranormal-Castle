using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class clockHandler : MonoBehaviour
{

    public UnityEvent finishEvents;

    public clockPointer hours;
    public clockPointer minutes;
    
    // the required solution for the clock
    public int requiredHours;
    public int requiredMinutes;
    
    int hoursTime = 10;
    int minutesTime = 50;

    Outline outline;
    // Start is called before the first frame update
    void Start(){
        outline = GetComponent<Outline>();
        outline.enabled = false;
        hours.setAngle(hoursTime);
        minutes.setAngle(minutesTime/5);

        
    }

    public void allowModification(){
        ClockHandlerSingleton.isActivated = false;
    }
    
    
    public void disAllowModification(){
        ClockHandlerSingleton.isActivated = true;

    }
    
    // USE [ContextMenu("NAME")] TO MAKE A FUNCTION APPEAR IN THE CONTEXT MENU DURIGN THE RUN MODE 

    // increase the hours by 1, up to 11
    [ContextMenu("+1 Hour")]
    public void IncreaseOneHour(){
        hours.setAngle(1);
        hoursTime+= 1;
        if (hoursTime == 12){
            hoursTime = 0;
        }
        checkCorrectTime();
    }
    // descrease the hours by 1. if negative, set it to 11
    [ContextMenu("-1 Hour")]
    public void DescreaseOneHour(){
        hours.setAngle(-1);
        hoursTime-= 1;
        if (hoursTime == -1){
            hoursTime = 11;
        }
        checkCorrectTime();
    }
    // increase the minutes by 5, up to 55
    [ContextMenu("+5 Minute")]
    public void IncreaseFiveMinutes(){
        minutes.setAngle(1);
        minutesTime+= 5;

        if (minutesTime >= 60){
            minutesTime = 0;
        }
        checkCorrectTime();
    }
    // decrease the minutes by 5. if negative, set to 55
    [ContextMenu("-5 Minute")]
    public void DescreaseFiveMinute(){
        minutes.setAngle(-1);
        minutesTime-= 5;

        if (minutesTime <= -1){
            minutesTime = 55;
        }

        checkCorrectTime();
    }

    // if time is correct, stop the player from any further clicking 
    // and make the clock glow, and take the focus out of the clock
    void checkCorrectTime(){
        if (hoursTime == requiredHours && minutesTime == requiredMinutes){
            Debug.Log("Player got correct time. Horray!!");
            StartCoroutine(doFinishAnimation());
        }
    }
    IEnumerator doFinishAnimation(){
        yield return new WaitForSeconds(1f);
        finishEvents.Invoke();
    }

}
