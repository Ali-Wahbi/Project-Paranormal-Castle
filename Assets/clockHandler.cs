using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockHandler : MonoBehaviour
{

    public clockPointer hours;
    public clockPointer minutes;
    int hoursTime = 7;
    int minutesTime = 30;
    // Start is called before the first frame update
    void Start(){
        hours.setAngle(hoursTime);
        minutes.setAngle(minutesTime/5);

        // IncreaseOneHour();
        // IncreaseOneHour();

        // IncreaseFiveMinutes();
        
        
    }

    // USE [ContextMenu("NAME")] TO MAKE A FUNCTION APPEAR IN THE CONTEXT MENU DURIGN THE RUN MODE 

    // increase the hours by 1, up to 11
    [ContextMenu("+1 Hour")]
    void IncreaseOneHour(){
        hours.setAngle(1);
        hoursTime+= 1;
        if (hoursTime == 12){
            hoursTime = 0;
        }
    }
    // descrease the hours by 1. if negative, set it to 11
    [ContextMenu("-1 Hour")]
    void DescreaseOneHour(){
        hours.setAngle(-1);
        hoursTime-= 1;
        if (hoursTime == -1){
            hoursTime = 11;
        }
    }
    // increase the minutes by 5, up to 55
    [ContextMenu("+5 Minute")]
    void IncreaseFiveMinutes(){
        minutes.setAngle(1);
        minutesTime+= 5;

        if (minutesTime >= 60){
            minutesTime = 0;
        }
    }
    // decrease the minutes by 5. if negative, set to 55
    [ContextMenu("-5 Minute")]
    void DescreaseFiveMinute(){
        minutes.setAngle(-1);
        minutesTime-= 5;

        if (minutesTime <= -1){
            minutesTime = 55;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
