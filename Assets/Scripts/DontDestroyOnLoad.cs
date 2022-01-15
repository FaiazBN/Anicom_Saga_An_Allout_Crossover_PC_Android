using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType<DontDestroyOnLoad>().Length > 1)
        {
            Destroy(gameObject);            
        }

        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        var  levelExistence = FindObjectOfType<LevelExistence>();
        if (!levelExistence)
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
