using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea(3,12)]
    string[] sentences;
    
    public SentenceEvents[] sentenceEvents; 

}

[System.Serializable]
public class SentenceEvents
{
    [TextArea(3,12)]
    public string sentences;
    public UnityEvent SenteceFinishedEvents;
 

}
