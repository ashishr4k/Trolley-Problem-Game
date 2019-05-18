using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    
    public GameController gameController;
    public GameObject button;
    public const int numScenarios = 3;
    public bool[] levelState;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numScenarios; i++)
        {
            button.GetComponent<LevelButton>().num = i+1;
            Instantiate(button, new Vector3(0, 1f-i, 0), Quaternion.identity);
        }

        levelState = GetLevels();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SaveState()
    {
        if (CheckArray(levelState))
        {
            Debug.Log("NOT ALLOWED");
        }
        else
        {
            SetLevels(levelState);
            gameController.LoadMainMenu();
        }
    }
    bool CheckArray(bool[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (!array[i])
            {
                return array[i];
            }
        }
        return true;
    }
    //code from https://answers.unity.com/questions/940020/playerprefsx-intarray.html for storing array in playerprefs modified for
    // Use this to set integer array
    public static void SetLevels(bool[] levels)
    {
        PlayerPrefs.SetString("Level", GetSerializedString(levels));
    }

    // Use this to get integer array
    public static bool[] GetLevels()
    {
        string[] data = PlayerPrefs.GetString("Level", "true").Split('|');
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
}
