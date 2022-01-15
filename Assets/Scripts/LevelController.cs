using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int numberOfAttackers = 0;
    [SerializeField] GameObject winAnimation;
    [SerializeField] GameObject loseAnimation;


    LevelLoader levelLoader;

    bool levelTimerFinished = false;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }


    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }
    public void AttackerDestroyed()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    public void ActivateLoseCondition()
    {
        loseAnimation.SetActive(true);
    }
    IEnumerator HandleWinCondition()
    {
        winAnimation.SetActive(true);
        yield return new WaitForSeconds(2f);
        levelLoader.LoadNextScene();
    }
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawner();
    }

    private void StopSpawner()
    {
        AttackerSpawner[] spwanerArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spwaner in spwanerArray)
        {
            spwaner.StopSpawning();
        }
    }
}
