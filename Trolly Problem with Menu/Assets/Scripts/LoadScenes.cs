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
            case "QuickStartButton":
                SceneManager.LoadScene("ScenarioExample");
                break;
            case "ResultsButton":
                SceneManager.LoadScene("None");
                break;
           // case "Finish":
            //    SceneManager.LoadScene("MainMenu");
              //  break;

        }
    }
}
