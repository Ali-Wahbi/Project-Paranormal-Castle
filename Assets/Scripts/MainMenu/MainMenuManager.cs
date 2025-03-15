using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainButtons;
    public GameObject PopButtons;

    public TMP_Text StartText;

    private void Start()
    {
        PopButtons.SetActive(false);
        SetStartText();
    }

    string _startText = "New Game";
    string _resumeText = "Resume";
    string fullPath = Application.dataPath + "/Saves/";
    void SetStartText()
    {
        if (!Directory.Exists(fullPath)) StartText.text = _startText;
        else StartText.text = _resumeText;
    }
    public void onPlayClicked()
    {
        // when the player clicks on play game
        Debug.Log("Starting the game");
        GoToMainArea();
    }

    public void onSettingsClicked()
    {
        Debug.Log("Switching to settings");
    }

    public void onExitClicked()
    {
        Debug.Log("Show pop, hide main");

        MainButtons.SetActive(false);
        PopButtons.SetActive(true);
    }

    public void onYesClicked()
    {
        Debug.Log("Exiting the game");
        Application.Quit();
    }

    public void onNoClicked()
    {
        Debug.Log("hide pop, show main");

        MainButtons.SetActive(true);
        PopButtons.SetActive(false);
    }

    void GoToMainArea()
    {
        SceneManager.LoadScene(1);
    }


}
