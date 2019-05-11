using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
        SceneManager.LoadScene("Game");
    }
}
