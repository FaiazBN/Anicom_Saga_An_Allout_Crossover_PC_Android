using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int lifeEnergyCost = 100;


    public void AddLifeEneregy(int amount)
    {
        FindObjectOfType<LifeEnergyDisplay>().AddLifeEnergy(amount);
    }
    public int GetLifeEnergyCost()
    {
        return lifeEnergyCost;
    }


}
