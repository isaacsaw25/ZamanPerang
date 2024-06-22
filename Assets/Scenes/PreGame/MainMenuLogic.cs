using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject difficultyMenu;
    public GameObject historyMenu;
    public GameObject menuSound;
    private AudioSource seaWaves;
    public TextMeshProUGUI soundOnText;
    public Slider slider;

    private void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        difficultyMenu.SetActive(false);
        historyMenu.SetActive(false);

        seaWaves = menuSound.GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("MusicLevel")) {
            PlayerPrefs.SetFloat("MusicLevel", 1);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        // Adjust the music and sound volume based on slider input
        slider.value = PlayerPrefs.GetFloat("MusicLevel");
        seaWaves.volume = slider.value;
    }

    public void PlayGame(float difficulty)
    {
        // Save the difficulty multiplier to PlayerPrefs
        PlayerPrefs.SetFloat("DifficultyMultiplier", difficulty);

        // Ensure the data is saved to disk
        PlayerPrefs.Save();

        // Load the main game scene
        SceneManager.LoadScene("mainGameScene");

    }

    public void AdjustMusicVolume(float level)
    {
        slider.value = level;
        PlayerPrefs.SetFloat("MusicLevel", level);
        PlayerPrefs.Save();
    }

    public void AdjustSoundVolume(float level)
    {
        slider.value = level;
        PlayerPrefs.SetFloat("MusicLevel", level);
        PlayerPrefs.Save();
    }

    public void VolumeToggle()
    {
        {
            if (PlayerPrefs.GetFloat("MusicLevel") > 0)
            {
                AdjustMusicVolume(0);
                soundOnText.text = "SOUND : OFF";
            } 
            else
            {
                AdjustMusicVolume(1);
                soundOnText.text = "SOUND : ON";
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
