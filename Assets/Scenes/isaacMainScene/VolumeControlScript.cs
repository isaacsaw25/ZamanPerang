using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControlScript : MonoBehaviour
{
    public GameObject OST;
    private AudioSource music;
    public TextMeshProUGUI soundOnText;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        AdjustMusicVolume(1.0f); // Enable full music by default
        AdjustSoundVolume(1.0f);

        music = OST.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Adjust the music and sound volume based on slider input
        PlayerPrefs.SetFloat("MusicLevel", slider.value);
        PlayerPrefs.Save();
        music.volume = PlayerPrefs.GetFloat("MusicLevel");
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
}
