using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    #region Properties
    TMP_Text TimerText;
    [SerializeField] GameObject TimerTextObject;

    [SerializeField] bool Autostart = false;
    // [SerializeField] bool Countdown = false;

    [SerializeField] int MaxTime = 10;
    public int currentTime = 0;

    string timer = "Time: ";

    bool isRunning = true; 

    #endregion
    
    private void Start() {
        TimerText = TimerTextObject.GetComponent<TMP_Text>();
        currentTime = MaxTime;
        SetTimeText(currentTime);
        
        if(Autostart){
            StartTimer();
        }
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            isRunning = false;
            Debug.Log("Stop timer runing");
        }
    }
    [ContextMenu("Start Timer")]
    void StartTimer(){
        isRunning = true;
        ShowTimer();
        StartCountDown();
        
    }

    #region Count Time down
    void StartCountDown(){


        StartCoroutine(DoCountDown());
    }

    IEnumerator DoCountDown(){

        while (currentTime > 0){

            yield return new WaitForSeconds(1);
            if (isRunning){
                currentTime -= 1;
                SetTimeText(currentTime);
            } else {
                StopAllCoroutines();
                HideTimer();
                Debug.Log("Time is Over");
            }
        }
        HideTimer();
        Debug.Log("Timer Reached end");

    }
    #endregion

    #region CountUp
    // void StartCountUp(){

    //     StartCoroutine(DoCountUp());

    // }
    // IEnumerator DoCountUp(){

    //     while (currentTime < MaxTime)
    //     {
            
    //         yield return new WaitForSeconds(1);

    //         if (isRunning){
    //             currentTime += 1;
    //             SetTimeText(currentTime);
    //         } else {
    //             StopAllCoroutines();
    //             Debug.Log("Time is up"); 
    //         }

    //     } 
        

    // }

    #endregion

    //Show The timer with an animation
    public void ShowTimer(){
        TimerTextObject.SetActive(true);
    }
    //Hide The timer with an animation
    public void HideTimer(){
        // fix hide timer and make an animation 
        TimerTextObject.SetActive(false);
    }

    //set the text in the UI screen
    void SetTimeText(int time){

        TimerText.text = timer + time;

    }
}
