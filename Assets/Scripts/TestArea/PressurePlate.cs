using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PrimeTween;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] UnityEvent onPressureOn;
    [SerializeField] UnityEvent onPressureOff;
    [SerializeField] float downHeight;
    [SerializeField] GameObject pathway;
    [SerializeField] float pathwayEndValue = -1.08f;
    bool pathOpen = false;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"){
            Debug.Log("Player Enter plate");
            PlateDownAnime();
            onPressureOn.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player"){
            Debug.Log("Player Exit plate");
            PlateUpAnime();
            onPressureOff.Invoke();
        }
    }

    void PlateDownAnime(){
        Vector3 down = new Vector3(transform.position.x, transform.position.y - downHeight, transform.position.z);
        // Tween tween = new Tween();
        Tween.Position(transform, endValue: down , duration: 1, ease: Ease.InOutSine)
        .OnComplete(() => PathwayOpen());;
    }


    void PlateUpAnime(){
        Vector3 down = new Vector3(transform.position.x, transform.position.y + downHeight, transform.position.z);
        Tween.Delay(1);
        Tween.Position(transform, endValue: down, duration: 1, ease: Ease.InOutSine);

    }

    void PathwayOpen(){
        Vector3 end = new Vector3(pathway.transform.position.x, pathway.transform.position.y - pathwayEndValue, pathway.transform.position.z);
        if (!pathOpen){
            Tween.Position(pathway.transform, endValue: end , duration:1, ease: Ease.InOutSine);  
            pathOpen = true;
        }

    }
}
