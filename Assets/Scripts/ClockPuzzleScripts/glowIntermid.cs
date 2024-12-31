using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowIntermid : MonoBehaviour
{
    
    [SerializeField]
    private GameObject chessPiece;
    public float intensity = 1.5f;

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
            // can change the intensity instead of the color - optional
            rend.material.SetColor("_EmissionColor", new Color(r, g, b) * intensity);
            yield return new WaitForSeconds(1/30);
        }
    }

    [ContextMenu("set Glow off")]
    private void setGlowOff(){
        rend.material.SetColor("_EmissionColor", new Color(0, 0, 0));
    }
}
