using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 5;
    [SerializeField] int damage = 1;
    TextMeshProUGUI livesDisplay;




    void Start()
    {
        livesDisplay = GetComponent<TextMeshProUGUI>();
        livesDisplay.text = lives.ToString();
        
    }

    public void LoseDamage()
    {
        lives -= damage;
        livesDisplay.text = lives.ToString();
        if(lives <= 0)
        {
            Time.timeScale = 0f;  // pauses the game after losing
            FindObjectOfType<LevelController>().ActivateLoseCondition();
            //FindObjectOfType<LevelLoader>().LoadLoseScene();
        }
    }


}
