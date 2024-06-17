using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(float difficulty)
    {
        // Save the difficulty multiplier to PlayerPrefs
        PlayerPrefs.SetFloat("DifficultyMultiplier", difficulty);

        // Ensure the data is saved to disk
        PlayerPrefs.Save();

        // Load the main game scene
        SceneManager.LoadScene("mainGameScene");

    }

    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
