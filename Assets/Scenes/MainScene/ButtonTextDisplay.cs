using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonTextDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TextMeshProUGUI hoverText; // Assign this in the Unity Inspector
    public string hoverMessage; // Assign the hover message for this button

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverText != null)
        {
            hoverText.text = hoverMessage;
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