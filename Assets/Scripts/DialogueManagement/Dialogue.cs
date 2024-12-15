using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea(3,12)]
    string[] sentences; // deprecated
    
    public SentenceEvents[] sentenceEvents; 

}

[System.Serializable]
public class SentenceEvents
{
    public string name;
    [TextArea(3,12)]
    public string sentences;
    public UnityEvent SenteceFinishedEvents; // can make the events only after the senteces end, not during it
 

}
