using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronThrone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Attackers attacker = otherCollider.GetComponent<Attackers>();

        if (attacker)
        {
            // Do Something!
        }
        
    }

}
