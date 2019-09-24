using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonControl : MonoBehaviour
{
    public GameObject buttonTemplate;
    int total;
    bool[] skipLevelState;
    [SerializeField]
    private DBController Database;
    // Start is called before the first frame update
    void Start()
    {
        Database.StartCoroutine(Database.GetTotal(1, Setup));
    }

    void Setup(int numScenarios, bool done)
    {
        if (done)
        {
            total = numScenarios;
            skipLevelState = new bool[total];

            string levelPrefs = PlayerPrefs.GetString("LevelsToSkip");
            if (string.IsNullOrEmpty(levelPrefs))
            {
                Debug.Log("Prefs empty... inserting default values");
                string skiplevels = "";
                foreach (bool item in skipLevelState)
                {
                    skiplevels += item + ",";
                }
                PlayerPrefs.SetString("LevelsToSkip", skiplevels);
            }
            else
            {
                string[] stringSeparators = new string[] { "," };
                string[] result = levelPrefs.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < skipLevelState.Length; i++)
                {
                    if (i >= result.Length) break;
                    bool.TryParse(result[i], out skipLevelState[i]);
                }
                //Debug.Log(levelPrefs);
            }

            for (int i = 0; i < total; i++)
            {
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);

                button.transform.SetParent(buttonTemplate.transform.parent, false);

                button.GetComponent<LevelSelectButton>().SetButton(i + 1);

                button.GetComponent<LevelSelectButton>().SetState(skipLevelState[i]);
            }
        }
    }

    public bool ButtonClicked(int levelID)
    {
        skipLevelState[levelID-1] = !skipLevelState[levelID-1];
        string skiplevels = "";
        foreach (bool item in skipLevelState)
        {
            skiplevels += item +  ",";
        }

        PlayerPrefs.SetString("LevelsToSkip", skiplevels);

        return skipLevelState[levelID - 1];
    }

    public bool GetLevelState(int levelID)
    {
        return skipLevelState[levelID-1];
    }
}
