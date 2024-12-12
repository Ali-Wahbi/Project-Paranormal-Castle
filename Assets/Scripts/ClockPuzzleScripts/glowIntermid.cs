using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowIntermid : MonoBehaviour
{
    
    [SerializeField]
    private GameObject chessPiece;

    // Color(r,g,b,a) = Color(1f, 0.9f, 0.5f)

    Renderer rend;
    void Start()
    {
        rend = chessPiece.GetComponent<Renderer>();
    }

    [ContextMenu("set Glow On")]
    public void setGlowOn(){
        
        StartCoroutine(StartGlowing());

    }
    
    IEnumerator StartGlowing(){
        float r = 0f;
        float g = 0f;
        float b = 0f;
        for (int i = 0; i < 60; i++)
        {
            r+= 1/60f;
            g+= 0.9f/60;
            b+= 0.5f/60;
            rend.material.SetColor("_EmissionColor", new Color(r, g, b));
            yield return new WaitForSeconds(1/30);
        }
    }

    [ContextMenu("set Glow off")]
    private void setGlowOff(){
        rend.material.SetColor("_EmissionColor", new Color(0, 0, 0));
    }
}
