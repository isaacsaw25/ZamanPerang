using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameLogic : MonoBehaviour
{
    public float difficultyMultiplier;   // This multiplier directly affects enemy units

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the difficulty multiplier from PlayerPrefs
        difficultyMultiplier = PlayerPrefs.GetFloat("DifficultyMultiplier", 1.0f);

        // Use the difficulty multiplier in your game logic
        Debug.Log("Difficulty Multiplier: " + difficultyMultiplier);

        // Retrieve the sound settings from PlayerPrefs
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinGame() { 

    }

    public void LoseGame()
    {

    }
}
