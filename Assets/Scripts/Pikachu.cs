using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikachu : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherCollider.GetComponent<IronThrone>())
        {
            GetComponent<Animator>().SetTrigger("isJumping");
        }
        else if (otherCollider.GetComponent<Defender>())
        {
            GetComponent<Attackers>().Attack(otherObject);

        }

    }

}