using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadingTime = 3f;
    [SerializeField] float beforeSceneLoadingTime = 3f;
    [SerializeField] int[] noEscScenes;

    int currentSceneIndex;
    
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadingScreenLoader();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i < noEscScenes.Length; i++)
            {
                if (currentSceneIndex == noEscScenes[i])
                {
                    return;
                }
            }
            SceneManager.LoadScene("Main Menu");
        }
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;         // Sets the time back to normal (We paused the game after losing)
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;         // Sets the time back to normal (We paused the game after losing)
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadLoseScene()
    {
        SceneManager.LoadScene("Lose Screen");
    }
    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options");
    }
    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LoadAboutScene()
    {
        SceneManager.LoadScene("About");
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadingScreenLoader()
    {
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadingScreenWait());             // Actual Wait Time
        }
    }
     public IEnumerator LoadingScreenWait()
    {
        yield return new WaitForSeconds(loadingTime);

        LoadNextSceneAfterWait();
    }
    public void LoadNextSceneAfterWait()
    {
        StartCoroutine(BeforeSceneLoadingTime());         // Time After loading Time Ended
    }
    public IEnumerator BeforeSceneLoadingTime()
    {
        HandelingUIStuffs();
        yield return new WaitForSeconds(beforeSceneLoadingTime);
        LoadNextScene();
    }
    private static void HandelingUIStuffs()
    {
        FindObjectOfType<LoadingScreenCharacterAnimation>().SetCharacterGone();   // Allows kakashi and aang to move away once the laoding time has finished
        FindObjectOfType<LoadingScreenHandler>().SetLoadingScreenTransitionOn();  // Allows our Black transition to active
        FindObjectOfType<LoadingScreenHandler>().PlaySharinganSFX();
    }
}
