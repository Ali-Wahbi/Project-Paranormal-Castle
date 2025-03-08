using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PrimeTween;
using Cinemachine;

public class GameEffects : MonoBehaviour
{
    [SerializeField] Camera cm;
    public float strengthFactor = 1.0f;
    public float duration = 1.0f;
    public float frequency = 10f;

    [SerializeField] UnityEvent onShakeStart;
    [SerializeField] UnityEvent onShakeEnd;

    public void ShakeCamera(){
        StartShake();
        Tween.ShakeCamera(cm, strengthFactor, duration, frequency)
        .OnComplete(() => EndShake());
    }

    void StartShake(){
        onShakeStart.Invoke();
        cm.GetComponent<CinemachineBrain>().enabled = false;
    }

    void EndShake(){
        onShakeEnd.Invoke();
        cm.GetComponent<CinemachineBrain>().enabled = true;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            Debug.Log("Shaking camera ");
            ShakeCamera();
        }
    }
}
