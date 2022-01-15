using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Attackers : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] float moveSpeed;
    GameObject currentTarget;
    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }
    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null)
        {
            levelController.AttackerDestroyed();
        }
    }
    void Start()
    {
    }
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        UpadteAnimationState();
    }

    private void UpadteAnimationState()
    {
        if (!currentTarget) 
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetWalkingSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }


    }


}
