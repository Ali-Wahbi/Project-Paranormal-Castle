using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewCamera : MonoBehaviour
{
    public float speed = 0.5f;
    int doSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) doSpeed = 1;
        Vector3 rotateValue = new Vector3(0, speed * doSpeed, 0);
        transform.Rotate(rotateValue);
    }
}
