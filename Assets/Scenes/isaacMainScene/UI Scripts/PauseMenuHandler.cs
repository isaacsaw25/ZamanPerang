using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    public bool isGamePaused;
    public GameObject PauseMenuCanvas;
    public AudioSource music;

    public GameObject optionMenu;
    public GameObject mainPauseMenu;
    public GameObject historyMenu;

    private void Start()
    {
        PauseMenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Reset pause menu to main pause menu state
        if (optionMenu != null)
        {
            optionMenu.SetActive(false);
        }
        if (mainPauseMenu != null)
        {
            mainPauseMenu.SetActive(true);
        }

        // Turn off the pause menu and resume the game
        PauseMenuCanvas.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1.0f;
        music.Play();
    }

    public void Pause()
    {
        PauseMenuCanvas.SetActive(true); // turn on the pause menu
        mainPauseMenu.SetActive(true);
        optionMenu.SetActive(false);
        
        // Keep track of the pause
        isGamePaused = true;
        Time.timeScale = 0f; // Stop time
        music.Pause();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
