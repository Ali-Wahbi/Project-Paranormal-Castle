using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveTeleporter : MonoBehaviour
{

    Material material;
    public bool reverse = false;
    public float duration = 2f;
    public float smoothness = 10f;
    public float counter = 1;

    [SerializeField] GameObject Player;
    int maxValue = 1;
    int minValue = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        SetDissolve(maxValue);
    }


    void SetDissolve(float value){
        material.SetFloat("_Dissolve",value);    
    }

    public void StartDissolve(){
        SetDissolve(maxValue);
        StartCoroutine(Dissolve());
    }

    // add reverse to the dissolve
    IEnumerator Dissolve(){
        
        ReverseDissolve(reverse);
        yield return new WaitForSeconds(2);

        while(counter > minValue){
            counter -= maxValue/(duration*smoothness);
            SetDissolve(counter);
            yield return null;
        }

        Player.SetActive(false);
        ReverseDissolve(!reverse);
        yield return new WaitForSeconds(1);
        
        while(counter < maxValue){
            counter += maxValue/(duration*smoothness);
            SetDissolve(counter);
            yield return null;
        }
    }

    void ReverseDissolve(bool rev){
        int state = rev? 1 : 0;
        material.SetInt("_Reverse", state);
    }
   
}
