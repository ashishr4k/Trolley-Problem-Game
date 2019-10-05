using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    private int levelID;
    private int scenarioID;
    public Text buttonText;

    [SerializeField]
    private LevelButtonControl levelButtonController;
    // Start is called before the first frame update
    void Start()
    {
        SetState(levelButtonController.GetLevelState(levelID));
    }

    public void SetButton(int sid, int lid)
    {
        scenarioID = sid;
        levelID = lid;
        buttonText.text = "Scenario " + sid;
    }

    public void OnClick()
    {
        SetState(levelButtonController.ButtonClicked(levelID));

    }

    public void SetState(bool value)
    {
        if (value)
        {
            gameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
    }
}
