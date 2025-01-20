using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor.Animations;

public class MistakesIndicator : MonoBehaviour
{
    [Header("Images Animators")]
    [SerializeField] Animator animator1;
    [SerializeField] Animator animator2;
    [SerializeField] Animator animator3;

    [Header("Animators Controllers")]
    [SerializeField] UnityEditor.Animations.AnimatorController animatorCircle;
    [SerializeField] UnityEditor.Animations.AnimatorController animatorCross;

    int mistakesCounter = 0;

    private void Start() {
        SetAllAnimCircle();
        Debug.Log(animator1.runtimeAnimatorController);
        // animator2.Play();
        // animator3.Play();
    }

    // Set All the mistake indicators to a circle animation and reset the counter
    void SetAllAnimCircle(){
        mistakesCounter = 0;
        animator1.runtimeAnimatorController = animatorCircle;
        animator2.runtimeAnimatorController = animatorCircle;
        animator3.runtimeAnimatorController = animatorCircle;
    }

    // add a mistake and show it in the screen
    [ContextMenu("Add Mistake")]
    public void AddMistakes(){
        ChangeCurrentToCross();
        mistakesCounter++;
    }

    // calls the set function
    [ContextMenu("Reset Mistakes")]
    public void ResetMistakes(){
        Debug.Log("Reseting mistakes");
        SetAllAnimCircle();
    }

    // change the current indicator to a cross animation
    void ChangeCurrentToCross(){
        switch (mistakesCounter)
        {
            case 0:
                animator1.runtimeAnimatorController = animatorCross;
                break;
            case 1:
                animator2.runtimeAnimatorController = animatorCross;
                break;
            case 2:
                animator3.runtimeAnimatorController = animatorCross;
                break;
            default: 
                break;
        }
    }
}
