using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayAudioAfterDelay : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public float soundDelay = 0.8f;      // Delay in seconds before playing the audio
    public float menuDelay = 2.0f;      // Delay in seconds before changing to menu
    public string MainMenu;

    void Start()
    {
        // Start the coroutine to play the audio after a delay
        StartCoroutine(PlayAudioWithDelay());
        StartCoroutine(gotoRealMenu());
    }

    IEnumerator PlayAudioWithDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(soundDelay);

        // Play the audio
        audioSource.Play();
    }

    IEnumerator gotoRealMenu()
    {
        yield return new WaitForSeconds(menuDelay);

        //switch the scene
        SceneManager.LoadScene(MainMenu);
    }
}
