using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> dialogueNames;
    private Queue<UnityEvent> sentenceEndEvents;

    [SerializeField] private Animator animator;
    
    [SerializeField] private UnityEvent onDialogueStarts; 
    [SerializeField] private UnityEvent onDialogueEnds; 
    // public TMP_Text nameText;
    public TMP_Text dialogueText;

    public float waitTime;

    private bool dialogueShown = false;
    private string speakerName = "";
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueNames = new Queue<string>();
        sentenceEndEvents = new Queue<UnityEvent>();
    }
    void Update() {
        if (dialogueShown && Input.GetKeyUp(KeyCode.F)){
            if(sentenceEndEvents.Count > 0){
                sentenceEndEvents.Dequeue().Invoke();
            }
            DisplayNextSentence();
        }
    }

    
    public void StartDialogue(Dialogue dialogue){
        onDialogueStarts.Invoke();
        animator.SetBool("DialogueStarts", true);
        animator.SetBool("DialogueEnds", false);
        
        dialogueShown = true;
        // Debug.Log("Dialogue with:" + dialogue.name);
        // nameText.text = dialogue.name;
        // speakerName = dialogue.name;
        sentences.Clear();
        dialogueNames.Clear();
        sentenceEndEvents.Clear();
        foreach (SentenceEvents sentenceEvent in dialogue.sentenceEvents)
        {
            sentences.Enqueue(sentenceEvent.sentences);
            dialogueNames.Enqueue(sentenceEvent.name);
            sentenceEndEvents.Enqueue(sentenceEvent.SenteceFinishedEvents);
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
            speakerName = dialogueNames.Dequeue();
            // dialogueText.text = sentence;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
            // Debug.Log(sentence);
        }
    }

    IEnumerator TypeSentence(string sentence){
        dialogueText.text = speakerName + " : ";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator Wait(float waitTime){
        yield return new WaitForSeconds(waitTime);
    }

    private void EndDialogue(){
        
        animator.SetBool("DialogueStarts", false);
        animator.SetBool("DialogueEnds", true);
        
        dialogueShown = false;

        onDialogueEnds.Invoke();
        
        // Debug.Log("End of dialogue reached");
    }
}
