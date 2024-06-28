using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class PopUpTextController : MonoBehaviour
{
    public TextMeshProUGUI popupText;

    // Start is called before the first frame update
    void Start()
    {
        popupText = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string text)
    {
        popupText = GetComponent<TextMeshProUGUI>();
        popupText.text = text;
    }
}
