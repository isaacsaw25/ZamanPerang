using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurrencyScript : MonoBehaviour
{
    public static float zpDollar = 175;
    public static float experience = 0;

    public bool addMoney;
    public bool addEXP;

    public GameObject currencyDisplay;
    private TextMeshProUGUI currencies;

    private void Start()
    {
        currencies = currencyDisplay.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (addMoney)
        {
            zpDollar += 1000;
            addMoney = false;
        }
        if (addEXP)
        {
            experience += 1000;
            addEXP = false;
        }

        if (currencies != null)
        {
            currencies.text = "ZP$ : " + zpDollar + "\n" + "EXP : " + experience;
        }
    }
}
