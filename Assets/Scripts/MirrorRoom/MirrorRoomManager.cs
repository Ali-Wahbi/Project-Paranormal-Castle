using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MirrorRoomManager : MonoBehaviour
{

    // puzzle manager
    // should hold a list of all puzzle items
    // when an item is clicked, it checks if the object in the list
    // if not it increases the number of mistakes by one
    //  and highlight a bulb with red color indicating one mistake

    [SerializeField] private List<GameObject> PuzzleItems;
    [SerializeField] private List<GameObject> MistakeIndicators;

    [SerializeField] private MistakesIndicator mistakesIndicatorManager;
    [SerializeField] private DialogueTrigger mistakesIndicatorDialogue;


    public Color incorrectColor;
    public Color originalColor;
    [SerializeField] private int maxMistakes;
    int numberOfMistakes = 0;  
    public int numberOfCorrect = 0;

    public UnityEvent onEndingEvents;
    
    // Start is called before the first frame update
    void Start()
    {
        if (maxMistakes > MistakeIndicators.Count){
            maxMistakes = MistakeIndicators.Count;
        }

        originalColor = MistakeIndicators[0].GetComponent<Renderer>().material.GetColor("_Color");
    }

    // check the selected item when it is clicked
    public void CheckSelectedItem(GameObject selectedItem){
        if (PuzzleItems.Contains(selectedItem)){
            Debug.Log("Correct Item");
            selectedItem.SetActive(false);

            CheckEndOfgame();
        } else {
            Debug.Log("Item is Incorrect");
            HandleMistakes();
        }
    }

    // when the player selects an incorrect item 
    void HandleMistakes(){

        // get current sphere to glow red
        GameObject currentSphere = MistakeIndicators[numberOfMistakes];
        ChangeSphereColor(currentSphere, incorrectColor);

        // show mistake in the screen 
        mistakesIndicatorManager.AddMistakes();

        numberOfMistakes++;
        if (numberOfMistakes >= maxMistakes){
            // restart puzzle
            Debug.Log("Player failed at puzzle. Restart.");
            // the dialogue if all mistakes are passed and then reset the puzzle
            mistakesIndicatorDialogue.TriggerDialogue();
            // RestartPuzzle();

        } else {
            
            Debug.Log("Player got wrong, " + (maxMistakes - numberOfMistakes) + " chances left.");
        
        }
    }
    // change the color of the spheres
    void ChangeSphereColor(GameObject sphere, Color color){
        Renderer rend = sphere.GetComponent<Renderer>();
        rend.material.SetColor("_Color", color);
    }

    void CheckEndOfgame(){
        numberOfCorrect++;

        if (numberOfCorrect >= PuzzleItems.Count){
            Debug.Log("Got all items in the room");
            onEndingEvents.Invoke();
        }
    }

    public void RestartPuzzle(){
        Debug.Log("Puzzle restarted");
        numberOfMistakes = 0;
        numberOfCorrect = 0;

        

        // reset the color of the spheres to its orginal color
        foreach (GameObject item in MistakeIndicators)
        {
            ChangeSphereColor(item, originalColor);
        }

        // reset all puzzle items
        foreach (GameObject item in PuzzleItems)
        {
            item.SetActive(true);
        }
    }

}
