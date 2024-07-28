using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    public Button targetButton; // The button to apply the cooldown to
    public float cooldownTime = 20f; // Cooldown duration in seconds

    private bool isOnCooldown = false; // Tracks if the button is on cooldown

    void Start()
    {
        // Ensure the button is assigned
        /*if (targetButton == null)
        {
            Debug.LogError("Target button is not assigned.");
            return;
        }*/

        // Assign the button click event
        targetButton.onClick.AddListener(() => StartCoroutine(HandleButtonCooldown()));
    }

    IEnumerator HandleButtonCooldown()
    {
        if (isOnCooldown)
        {
            Debug.Log("Button is on cooldown.");
            yield break;
        }

        isOnCooldown = true;

        // Perform the button's action here (if any)

        // Disable the button
        targetButton.interactable = false;

        // Wait for the cooldown time before allowing the button to be used again
        yield return new WaitForSeconds(cooldownTime);

        // Re-enable the button
        targetButton.interactable = true;

        isOnCooldown = false;
    }
}
