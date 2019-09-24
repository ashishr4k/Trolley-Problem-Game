using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
        if (PlayerPrefs.GetString("Layout") == "")
        {
            PlayerPrefs.SetString("Layout", "Train");
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadResultsScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("Level Selection");
    }
    public void LoadGame()
    {
        PlayerPrefs.SetString("Quick", "No");
        SceneManager.LoadScene("Game");
    }
    public void QuickStartGame()
    {
        PlayerPrefs.SetString("Quick", "Yes");
        PlayerPrefs.SetString("Reset", "Yes");
        SceneManager.LoadScene("Game");
    }
}
