using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeAudio : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType<LevelThreeAudio>().Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        var loseLevel = FindObjectOfType<LoseLevel>();
        var MainMenu = FindObjectOfType<MainMenu>();

        if (loseLevel)
        {
            Destroy(gameObject);
        }

        else if (MainMenu)
        {
            Destroy(gameObject);
        }
    }
}
