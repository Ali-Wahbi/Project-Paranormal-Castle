using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockPointer : MonoBehaviour
{
    [SerializeField]
    int initiativeTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // setAngle(initiativeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getTime(){
        
    }

    // TODO: add animation to the rotation of the pointer
    // increase or decrease the angle of the pointer, by passing 1 or -1
    public void setAngle(int newDirection){
        float newAngle = newDirection;
        Debug.Log("angle = " + newAngle);

        // transform.rotation = new Vector3(0, 0, newAngle);
        Vector3 rotate = new Vector3(0, 0, -newAngle);

        for (int i = 0; i < 30; i++)
        {
            transform.Rotate(rotate);
            
        }


    }
}
