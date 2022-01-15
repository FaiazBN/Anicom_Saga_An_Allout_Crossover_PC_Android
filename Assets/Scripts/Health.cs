using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject blastVFX;
    [SerializeField] GameObject blastPos; 

    public void DealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
            BlastVFX();
        }
    }

    private void BlastVFX()
    {
        if (!blastVFX)
        {
            return;
        }
        GameObject inititateBlast = Instantiate(blastVFX, transform.position,transform.rotation);
        Destroy(inititateBlast, 1f);
    }
}
