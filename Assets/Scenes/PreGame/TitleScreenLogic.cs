using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayAudioAfterDelay : MonoBehaviour
{
    public AudioSource clinkSound;     // Reference to the AudioSource component
    public float soundDelay = 0.8f;     // Delay in seconds before playing the audio
    public float textDelay = 1.5f;      // Delay in seconds till show text
    public float textKillDelay = 2.5f;  // Delay in seconds till kill text
    public float menuDelay = 3.0f;      // Delay in seconds before changing to menu
    public GameObject text;
    public string MainMenu;

    void Start()
    {
        // Set the screen orientation to auto-rotate between landscape left and right
        Screen.orientation = ScreenOrientation.AutoRotation;

        // Allow auto-rotation only to landscape modes
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        text.gameObject.SetActive(false);    // Turn off the text first
        // Start the coroutine to play animate the title screen
        StartCoroutine(PlayAudioWithDelay());
        StartCoroutine(ShowText());
        StartCoroutine(KillText());
        StartCoroutine(GoToRealMenu());
    }

    IEnumerator PlayAudioWithDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(soundDelay);

        // Play audio
        clinkSound.Play();
    }

    IEnumerator GoToRealMenu()
    {
        yield return new WaitForSeconds(menuDelay);

        // Switch the scene
        SceneManager.LoadScene(MainMenu);
    }
    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(textDelay);

        // Turn on the text
        text.gameObject.SetActive(true);
    }

    IEnumerator KillText()
    {
        yield return new WaitForSeconds(textKillDelay);

        // Turn off the text
        text.gameObject.SetActive(false);
    }
}
