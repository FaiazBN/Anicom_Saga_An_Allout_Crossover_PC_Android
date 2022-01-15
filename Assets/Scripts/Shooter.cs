using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject attackObject;
    [SerializeField] GameObject attackObjectPosition;
    [SerializeField] AudioClip attackObjectSFX;
    [SerializeField] [Range(0,1)]float attackObjectSFXVolume;
    AudioSource myAudio;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Prijectiles";

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        SetLaneSpawner();

        CreateProjectileParent();
        
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
    
    public void Fire()
    {
        GameObject newProjectile = Instantiate(attackObject, attackObjectPosition.transform.position, transform.rotation) as GameObject;

        newProjectile.transform.parent = projectileParent.transform;
        myAudio.PlayOneShot(attackObjectSFX, attackObjectSFXVolume);

    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            // Mathf.Abs rounds our numbers to positive value & Mathf.Epsilon finds the lowest possible number
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y)) <= Mathf.Epsilon;
            if (isCloseEnough)
            {
                myLaneSpawner = spawner; // this is the one that has the same y coordinate as our defender
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
}
