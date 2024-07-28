using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TurretTextDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TextMeshProUGUI hoverText; // Assign this in the Unity Inspector
    public GameObject MainController;
    public int currentAge;

    public void OnPointerEnter(PointerEventData eventData)
    {
        currentAge = MainController.GetComponent<ChangeSpecial>().currentAge;

        if (currentAge == 0)
        {
            hoverText.text = "Build Turret - ZP$ 2000";
        }
        if (currentAge == 1)
        {
            hoverText.text = "Build Turret - ZP$ 8000";
        }
        if (currentAge == 2)
        {
            hoverText.text = "Build Turret - ZP$ 25000";
        }
        if (currentAge == 3)
        {
            hoverText.text = "Build Turret - ZP$ 80000";
        }
        if (currentAge == 4)
        {
            hoverText.text = "Build Turret - ZP$ 500000";
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