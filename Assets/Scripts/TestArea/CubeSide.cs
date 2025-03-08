using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSide : MonoBehaviour
{
    public Sides currentSide;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Ground"){
            // Debug.Log("Colliding with side: "+ currentSide);
            transform.GetComponentInParent<CubePlayer>().FloorSide(currentSide);
        } 
    }
}
