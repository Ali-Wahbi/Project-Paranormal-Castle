using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulumAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxAngleDeflection = 30.0f;
    public float SpeedOfPendulum = 1.0f;
    private bool canSwing = false;
    // Update is called once per frame
    void Update()
    {
        if (canSwing){
            float angle = MaxAngleDeflection * Mathf.Sin(Time.time * SpeedOfPendulum);
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
    [ContextMenu("Swing")]
    public void EnableSwing(){
        canSwing = true;
    }
}
