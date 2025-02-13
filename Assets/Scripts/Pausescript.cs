using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    private bool isPaused = false; // Tracks the game's paused state
    public GameObject pausescreen; // Reference to the pause screen UI GameObject

    // public bool MouseState = false;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the pause screen is hidden initially
        if (pausescreen != null)
        {
            pausescreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for user input to toggle the pause state
        if (Input.GetKeyDown(KeyCode.Escape)) // Replace 'Escape' with any key or input you prefer
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        // Handle cursor appearance:
        // Get mouse current visability
        // MouseState = Cursor.visible;
        // Show mouse cursor
        // Cursor.visible = true;


        Time.timeScale = 0; // Stop time
        isPaused = true;

        if (pausescreen != null)
        {
            pausescreen.SetActive(true); // Show the pause screen
        }


        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // Resume time
        isPaused = false;

        if (pausescreen != null)
        {
            pausescreen.SetActive(false); // Hide the pause screen
        }


        // Handle cursor appearance:
        // Return mouse cursor to original state
        // Debug.Log("Mouse visible: " + Cursor.visible);
        // Cursor.visible = MouseState;

        Debug.Log("Game Resumed");
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1; // Resume time
        Debug.Log("Quit is called");
        SceneManager.LoadScene(0);
    }
}
