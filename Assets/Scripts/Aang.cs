using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aang : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherCollider.GetComponent<Defender>())
        {
            GetComponent<Attackers>().Attack(otherObject);

        }

    }
}
