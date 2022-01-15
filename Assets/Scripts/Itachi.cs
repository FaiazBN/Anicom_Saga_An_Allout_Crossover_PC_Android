using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itachi : MonoBehaviour
{
    [SerializeField] GameObject shuriken;
    [SerializeField] GameObject shurikenPosition;
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherCollider.GetComponent<AttackersThrowingArea>())
        {
            GetComponent<Attackers>().Attack(otherObject);
           
        }
        
    }
    public void ItachiShurikenThrow()
    {
        GameObject shurikenThorw = Instantiate(shuriken, shurikenPosition.transform.position, transform.rotation);
        Destroy(shurikenThorw, 10f);
    }

}
