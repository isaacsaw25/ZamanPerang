using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TurretTowerTextDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TextMeshProUGUI hoverText; // Assign this in the Unity Inspector
    public GameObject MainController;
    public int currentAge;

    public void OnPointerEnter(PointerEventData eventData)
    {
        currentAge = MainController.GetComponent<turretDeployment>().numOfTurretSpots;

        if (currentAge == 0)
        {
            hoverText.text = "Build Turret Tower - ZP$ 1000";
        }
        if (currentAge == 1)
        {
            hoverText.text = "Build Turret Tower - ZP$ 5000";
        }
        if (currentAge == 2)
        {
            hoverText.text = "Build Turret Tower - ZP$ 25000";
        }
        if (currentAge == 2)
        {
            hoverText.text = "Max Turret Towers";
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverText != null)
        {
            hoverText.text = "";
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (hoverText != null)
        {
            hoverText.text = "";
        }
    }
}