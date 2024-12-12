using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    
    public void StartDialogue(Dialogue dialogue){
        
        // Debug.Log("Dialogue with:" + dialogue.name);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (SentenceEvents sentenceEvent in dialogue.sentenceEvents)
        {
            sentences.Enqueue(sentenceEvent.sentences);
        }

        DisplayNextSentence();
    }

    [ContextMenu("Next Sentence")]
    void DisplayNextSentence(){
        if (sentences.Count == 0){
            EndDialogue();
            return;
        }
        else {
            string sentence = sentences.Dequeue();

            // dialogueText.text = sentence;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
            // Debug.Log(sentence);
        }
    }

    IEnumerator TypeSentence(string sentence){
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void EndDialogue(){
        Debug.Log("End of dialogue reached");
    }
}
