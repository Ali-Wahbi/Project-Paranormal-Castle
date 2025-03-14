using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeArea : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"){
            Debug.Log("Player entered");
            GetComponentInParent<GameEffects>().ShakeCamera();
        }
    }
}
