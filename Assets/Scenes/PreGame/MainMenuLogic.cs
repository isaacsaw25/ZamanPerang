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
    private bool isMuted;

    private void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        difficultyMenu.SetActive(false);
        historyMenu.SetActive(false);

        seaWaves = menuSound.GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("MusicLevel")) 
        {
            PlayerPrefs.SetFloat("MusicLevel", 1);
            PlayerPrefs.Save();
        }

        slider.value = PlayerPrefs.GetFloat("MusicLevel");
    }

    private void Update()
    {
        // Adjust the music and sound volume based on slider input
        if (!isMuted)
        {
            // Adjust the music and sound volume based on slider input
            PlayerPrefs.SetFloat("MusicLevel", slider.value);
            PlayerPrefs.Save();
            seaWaves.volume = PlayerPrefs.GetFloat("MusicLevel");
        }
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

    public void AdjustMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicLevel", slider.value);
        PlayerPrefs.Save();
    }

    public void AdjustSoundVolume(float level)
    {
        PlayerPrefs.SetFloat("MusicLevel", slider.value);
        PlayerPrefs.Save();
    }

    public void VolumeToggle()
    {
        {
            if (!isMuted)
            {
                seaWaves.volume = 0;
                slider.value = 0;
                isMuted = true;
                soundOnText.text = "SOUND : OFF";
            }
            else
            {
                isMuted = false;
                if (slider.value > 0)
                {
                    PlayerPrefs.SetFloat("MusicLevel", slider.value);
                    PlayerPrefs.Save();
                }
                else
                {
                    slider.value = PlayerPrefs.GetFloat("MusicLevel");
                }
                seaWaves.volume = slider.value;
                soundOnText.text = "SOUND : ON";
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
