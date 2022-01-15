using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObject : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float dealDamage = 50f;
   


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        Destroy(gameObject, 3f);
        
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attackers>();
        if (attacker && health)
        {
            health.DealDamage(dealDamage);
            if (tag != "Don'tDestroy")
            {
                Destroy(gameObject);
            }
        }

    }
}
