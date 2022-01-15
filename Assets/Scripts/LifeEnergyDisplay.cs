using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeEnergyDisplay : MonoBehaviour
{
    [SerializeField] int lifeEnergy = 150;
    TextMeshProUGUI lifeEnergyAmount;
    
    void Start()
    {
        lifeEnergyAmount = GetComponent<TextMeshProUGUI>();        
    }

    void Update()
    {
        DisplayEnergy();
    }

    public bool isAllowedToSpwan(int lifeErgCost)
    {      
        return lifeEnergy >= lifeErgCost;
    }

    private void DisplayEnergy()
    {
        lifeEnergyAmount.text = lifeEnergy.ToString();
    }
    public void AddLifeEnergy(int amount)
    {
        lifeEnergy += amount;
        DisplayEnergy();
    }
    public void ReduceLifeEnergy(int amount)
    {
        if (lifeEnergy >= amount)
        {
            lifeEnergy -= amount;
            DisplayEnergy();
        }
    }
}
