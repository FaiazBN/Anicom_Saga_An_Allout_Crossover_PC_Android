using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendableArea : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Attackers attacker = otherCollider.GetComponent<Attackers>();
        Lives live = FindObjectOfType<Lives>();
        LevelController level = FindObjectOfType<LevelController>();

        if (attacker)
        {
            live.LoseDamage();
            Destroy(otherCollider.gameObject);
        }
        

    }

}
