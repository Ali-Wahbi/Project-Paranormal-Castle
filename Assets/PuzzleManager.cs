using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    // number Of Solved Clocks
    int solvedClocks = 0;
    // number Of Clocks in the puzzle
    int numberOfClocks = 3;
    
    [SerializeField]
    UnityEvent OnSolved; 

    // add one to the solved puzzles then check if the puzzle has ended 
    public void AddToSolvedClocks(){
        solvedClocks++;
        CheckIfFinished();
    }

    // if the puzzle has been solved, handle the end logic 
    void CheckIfFinished(){
        if (solvedClocks == numberOfClocks){
            FinishLogic();
        }
    }

    // call all of the function at the end
    void FinishLogic(){
        OnSolved.Invoke();
        Debug.Log("Finish Logic is running");
    }
}
