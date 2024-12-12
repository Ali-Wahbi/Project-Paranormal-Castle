using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HudController : MonoBehaviour
{
   public static HudController instance;

   private void Awake() {
        instance = this;
   }

   [SerializeField]
   TMP_Text interactionText;

   public void EnableInteractionText(string text, Color textColor){
        interactionText.text = text + " (F)";
        interactionText.color = textColor;
        interactionText.gameObject.SetActive(true);
   }
   public void DisableInteractionText(){
        interactionText.gameObject.SetActive(false);
   }
}
