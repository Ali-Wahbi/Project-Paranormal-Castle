using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RewardsManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onFinishEvents;

    public void PuzzleFinished()
    {
        Debug.Log("Puzzle Finished");
        onFinishEvents.Invoke();
    }

}
