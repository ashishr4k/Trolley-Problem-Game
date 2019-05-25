using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    // Start is called before the first frame update
    public void SelectScene()
    {
        switch (this.gameObject.name)
        {
            case "LevelSelectButton":
                SceneManager.LoadScene("Level Selection");
                break;
            case "Quit":
                SceneManager.LoadScene("MainMenu");
                break;
            case "QuickStartButton":
                SceneManager.LoadScene("Game");
                break;
            case "ResultsButton":
                //SceneManager.LoadScene("None");
                Debug.Log("No Results Scene");
                break;
        }
    }
}
