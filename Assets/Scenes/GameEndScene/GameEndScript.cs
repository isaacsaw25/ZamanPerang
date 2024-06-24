using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScript : MonoBehaviour
{
    public AudioSource seaWaves;
    public TextMeshProUGUI splashText;

    private void Start()
    {
        // Set text bsed on victory or loss
        if (PlayerPrefs.GetInt("winState") == 1)
        {
            splashText.text = "Victory!!";
        }
        else
        {
            splashText.text = "Game Over...";
        }
        // Set the volume of the sea waves according to the settings
        seaWaves.volume = PlayerPrefs.GetFloat("MusicLevel");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
