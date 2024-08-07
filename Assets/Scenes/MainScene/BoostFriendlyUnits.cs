using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostFriendlyUnits : MonoBehaviour
{
    public LayerMask friendlyLayer; // Assign the layer mask for friendly units in the inspector
    public float healthBoost = 2; // Amount to boost health
    public float damageBoost = 2; // Amount to boost damage

    public void Activate()
    {
        GameObject[] friendlyUnits = GetAllFriendlyUnits();
        foreach (var unit in friendlyUnits)
        {
            ApplyBoost(unit);
        }
    }

    private GameObject[] GetAllFriendlyUnits()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        var friendlyUnits = new List<GameObject>();

        foreach (var obj in allObjects)
        {
            if (((1 << obj.layer) & friendlyLayer) != 0 && obj.GetComponent<BaseScript>() == null)
            {
                friendlyUnits.Add(obj);
            }
        }

        return friendlyUnits.ToArray();
    }

    private void ApplyBoost(GameObject unit)
    {
        // Boost health and damage
        var healthComponent = unit.GetComponent<CharacterHealth>();
        if (healthComponent != null)
        {
            healthComponent.currentHealth *= healthBoost;
        }

        var damageComponent = unit.GetComponent<CharacterAttack>();
        if (damageComponent != null)
        {
            damageComponent.rangedDamage *= damageBoost;
            damageComponent.meleeDamage *= damageBoost;
        }
    }
}
