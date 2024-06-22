using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScript : MonoBehaviour
{
    public AudioSource seaWaves;

    // Set the volume of the sea waves according to the settings
    private void Start()
    {
        seaWaves.volume = PlayerPrefs.GetFloat("MusicLevel");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
