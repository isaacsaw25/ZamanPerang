using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceScript : MonoBehaviour
{
    public float[] experience = {4000, 14000, 45000, 200000, 1000000};
    public int currentAge = 0;

    public bool upgradeAge()
    {
        if (currentAge < 4 && CurrencyScript.experience >= experience[currentAge])
        {
            currentAge++;
            return true;
        }
        return false;
    }
}
