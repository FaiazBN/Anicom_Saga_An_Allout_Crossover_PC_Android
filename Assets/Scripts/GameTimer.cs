using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Game Timer In Seconds")]
    [SerializeField] float gameTimer = 10f;
    bool triggerLevelTimerFinished = false;

    void Update()
    {
        if (triggerLevelTimerFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / gameTimer;

        bool timeFinished = Time.timeSinceLevelLoad >= gameTimer;

        if (timeFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggerLevelTimerFinished = true;
        }
        
    }
}
