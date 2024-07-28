using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class SuperTextDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TextMeshProUGUI hoverText; // Assign this in the Unity Inspector
    public GameObject MainController;
    public int currentAge;

    public void OnPointerEnter(PointerEventData eventData)
    {
        currentAge = MainController.GetComponent<ChangeSpecial>().currentAge;

        if (currentAge == 0)
        {
            hoverText.text = "Upgrade age - 12000 EXP";
        }
        if (currentAge == 1)
        {
            hoverText.text = "Upgrade age - 45000 EXP";
        }
        if (currentAge == 2)
        {
            hoverText.text = "Upgrade age - 150000 EXP";
        }
        if (currentAge == 3)
        {
            hoverText.text = "Upgrade age - 500000 EXP";
        }
        if (currentAge == 4)
        {
            hoverText.text = "Max age reached";
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