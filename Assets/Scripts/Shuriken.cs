using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float dealDamage = 50f;
    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var defender = otherCollider.GetComponent<Defender>();
        if (defender && health)
        {
            health.DealDamage(dealDamage);
            if (tag != "Don'tDestroy")
            {
                Destroy(gameObject);
            }
        }

    }
}
