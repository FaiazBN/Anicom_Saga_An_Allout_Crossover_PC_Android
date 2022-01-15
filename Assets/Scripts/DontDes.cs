using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDes : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        var levelThree = FindObjectOfType<LevelThree>();
        var MainMenu = FindObjectOfType<MainMenu>();

        if (levelThree)
        {
            Destroy(gameObject);
        }

        else if (MainMenu)
        {
            Destroy(gameObject);
        }
    }
}
