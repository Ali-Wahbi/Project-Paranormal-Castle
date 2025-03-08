using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SlicesCounter : MonoBehaviour
{
    [SerializeField] int numberOfSlices = 8;
    [SerializeField] UnityEvent onFinishEvents;
    int slicesCounter = 0;


    public void IncrementCounter()
    {
        slicesCounter++;
        CheckIfFinished();
    }

    void CheckIfFinished()
    {
        if (slicesCounter == numberOfSlices)
        {
            FinishLogic();
        }
    }

    void FinishLogic()
    {
        onFinishEvents.Invoke();
    }
}
