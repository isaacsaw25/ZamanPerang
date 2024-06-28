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

    private bool isMuted;

    // Start is called before the first frame update
    void Start()
    {
        music = OST.GetComponent<AudioSource>();
        music.volume = PlayerPrefs.GetFloat("MusicLevel");
        slider.value = music.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMuted)
        {
            // Adjust the music and sound volume based on slider input
            PlayerPrefs.SetFloat("MusicLevel", slider.value);
            PlayerPrefs.Save();
            music.volume = PlayerPrefs.GetFloat("MusicLevel");
        }
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
                music.volume = 0;
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
                music.volume = slider.value;
                soundOnText.text = "SOUND : ON";
            }
        }
    }
}
