using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainButtons;
    public GameObject PopButtons;

    private void Start() {
        PopButtons.SetActive(false);
    }
    public void onPlayClicked(){
        // when the player clicks on play game
        Debug.Log("Starting the game");
        GoToMainArea();
    }

    public void onSettingsClicked(){
        Debug.Log("Switching to settings");
    }

    public void onExitClicked(){
        Debug.Log("Show pop, hide main");

        MainButtons.SetActive(false);
        PopButtons.SetActive(true);
    }

    public void onYesClicked(){
        Debug.Log("Exiting the game");
        Application.Quit();
    }

    public void onNoClicked(){
        Debug.Log("hide pop, show main");

        MainButtons.SetActive(true);
        PopButtons.SetActive(false);
    }

    void GoToMainArea(){
        SceneManager.LoadScene(1);
    }

    
}
