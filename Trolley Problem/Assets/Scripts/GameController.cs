using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    private const int numScenarios = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Layout") == "")
        {
            PlayerPrefs.SetString("Layout", "Train");
        }
        bool[] a = GetLevels();
        if (PlayerPrefs.GetString("Version") != "2")
        {
            bool[] level = new bool[numScenarios];
            for(int i  = 0; i < numScenarios; i++)
            {
                level[i] = false;
            }
            SetLevels(level);
            Debug.Log("setting all levels");
            PlayerPrefs.SetString("Version", "2");
        }
    }

    public static void SetLevels(bool[] levels)
    {
        PlayerPrefs.SetString("Level", GetSerializedString(levels));
    }

    // Use this to get integer array
    public static bool[] GetLevels()
    {
        string[] data = PlayerPrefs.GetString("Level", "true").Split('|');
        //Debug.Log(data.Length);
        bool[] val = new bool[data.Length];
        bool levelState;
        for (int i = 0; i < val.Length; i++)
        {
            val[i] = bool.TryParse(data[i], out levelState) ? levelState : false;
        }
        return val;
    }

    private static string GetSerializedString(bool[] data)
    {
        if (data.Length == 0) return string.Empty;

        string result = data[0].ToString();
        for (int i = 1; i < data.Length; i++)
        {
            result += ("|" + data[i]);
        }
        return result;
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
    public void QuickStartGame()
    {
        bool[] a = GetLevels();
        bool[] level = new bool[numScenarios];
        for (int i = 0; i < numScenarios; i++)
        {
            level[i] = false;
        }
        SetLevels(level);
        //Debug.Log("Quick Start");

        SceneManager.LoadScene("Game");
    }
}
