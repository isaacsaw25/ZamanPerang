using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    public bool isGamePaused;
    public GameObject PauseMenuCanvas;
    public AudioSource music;

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
        PauseMenuCanvas.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1.0f;
        music.Play();
    }

    public void Pause()
    {
        PauseMenuCanvas.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0f;
        music.Pause();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
