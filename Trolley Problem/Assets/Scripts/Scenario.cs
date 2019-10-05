using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Scenario : MonoBehaviour
{
    private static int id = 1;

    private int outcomes;
    public int curr_out = 2;
    public Text[] choiceText;
    public GameObject train;
    public Animator m_Animator;
    public GameObject EndScreen;
    public Text EndScreenText;
    public GameObject Finish;
    public GameObject Next;

    int people1;
    int people2;
    int people3;

    public GameObject Track3;
    public GameObject Switch2;

    int totalScenarios;

    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;

    //public GameObject Person;
    public GameObject tutorialPanel;
    public Canvas canvas;
    public Text timeText;
    [SerializeField]
    private DBController Database;

    public GameObject[] characters;
    private bool[] SkipLevels;
    private int[] scenarioList;
    private int WaitTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        string levelPrefs = PlayerPrefs.GetString("LevelsToSkip");
        string[] stringSeparators = new string[] { "," };
        string[] result = levelPrefs.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

        SkipLevels = new bool[result.Length];

        for (int i = 0; i < result.Length; i++){
            bool.TryParse(result[i], out bool state);
            SkipLevels[i] = state;
        }

        if (PlayerPrefs.GetString("Reset") == "Yes")
        {
            id = 1;
            PlayerPrefs.SetString("Reset", "No");
        }

        if (PlayerPrefs.GetString("Quick") == "No") id = CheckForSkip();
        StartCoroutine("ScenarioSetup");
    }

    IEnumerator ScenarioSetup(){
        yield return Database.GetScenarioList(ScenarioList);
        Database.StartCoroutine(Database.GetScenarioData(scenarioList[id-1], ScenarioData));
    }

    void ScenarioList(string data, bool done){
        if (!done || string.IsNullOrEmpty(data)) return;
        string[] stringSeparators = new string[] { "," };
        string[] result = data.Split(stringSeparators, System.StringSplitOptions.RemoveEmptyEntries);

        scenarioList = new int[result.Length];
        for (int i = 0; i < result.Length; i++){
            scenarioList[i] = int.Parse(result[i]);
        }
    }

    void ScenarioData(string data, bool done)
    {
        //Debug.Log(data + ";" + id);
        if (!done || string.IsNullOrEmpty(data)) return;

        string[] stringSeparators = new string[] { "," };
        string[] result = data.Split(stringSeparators, System.StringSplitOptions.None);

        outcomes = int.Parse(result[1]);
        people1 = int.Parse(result[2]);
        people2 = int.Parse(result[3]);
        people3 = int.Parse(result[4]);
        choiceText[0].text = result[5];
        choiceText[1].text = result[6];
        choiceText[2].text = result[7];
        EndScreenText.text = result[8] + " of players made the same choice as you";
        string chars1 = result[9];
        string chars2 = result[10];
        string chars3 = result[11];
        WaitTime = int.Parse(result[12]);
        train.GetComponent<TrackSwitch>().SetWaitTime(WaitTime);

        if(int.Parse(result[13]) == 0){
            //Debug.Log("T");
            train.GetComponent<SpriteSwitch>().SetLayout("Train");
        }else{
            //Debug.Log("C");
            train.GetComponent<SpriteSwitch>().SetLayout("Car");
        }

        totalScenarios = int.Parse(result[result.Length -1]);

        //people on tracks
        CreatePeople(people1, spawner1, chars1);
        CreatePeople(people2, spawner2, chars2);
        CreatePeople(people3, spawner3, chars3);

        if (outcomes < 3)
        {
            Track3.SetActive(false);
            Switch2.SetActive(false);
        }

        //m_Animator = train.GetComponent<Animator>();
        EndScreen.SetActive(false);

        tutorialPanel.SetActive(false);

        //Tutorial
        if (id == 1)
        {
            tutorialPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        Vector3 offset = new Vector3(0.8f, 0.5f, 0);
        Vector3 offset2 = new Vector3(0.8f, -0.5f, 0);
        choiceText[0].transform.position = worldToUISpace(canvas, spawner1.transform.position + offset);
        choiceText[1].transform.position = worldToUISpace(canvas, spawner2.transform.position + offset);
        choiceText[2].transform.position = worldToUISpace(canvas, spawner3.transform.position + offset2);
    }

    int CheckForSkip()
    {
        for (int i = id - 1; i < SkipLevels.Length; i++)
        {
            if (SkipLevels[i])
            {
                return i+1;
            }
        }
        return SkipLevels.Length + 1;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            tutorialPanel.SetActive(false);
        }
        float maxWait = 30;
        timeText.text = "Arrives in: " + Mathf.Clamp(WaitTime - (int)Time.timeSinceLevelLoad, 0f, maxWait) + " seconds";
    }

    void CreatePeople(int nPeople, GameObject startPos, string chars)
    {
        string[] stringSeparators = new string[] { ";" };
        string[] result = chars.Split(stringSeparators, System.StringSplitOptions.RemoveEmptyEntries);

        int charID = 0;
        for (int i = 0; i < nPeople; i++)
        {
            float offset = (float)i / 2;
            if(result.Length != 0){
                charID = int.Parse(result[i]);
            }else{
                charID = 0;
            }
            GameObject person = Instantiate(characters[charID], startPos.transform.position + (offset * Vector3.right), Quaternion.identity) as GameObject;
        }
    }

	public void ScenearioEnd(){
        int clicks = Switch2.GetComponentInChildren<TrackSwitchButton>().getClicks();
        float timeTaken = Switch2.GetComponentInChildren<TrackSwitchButton>().getFirstTime();
        Database.StartCoroutine(Database.Submit(scenarioList[id-1], clicks, timeTaken, curr_out));

        id++;
        if (PlayerPrefs.GetString("Quick") == "No") id = CheckForSkip();
        //Debug.Log("Choice Made: " + m_Animator.GetInteger("Track"));
        //Debug.Log("Next Scene ID: " + id);

        //Next scenario or finish
        EndScreen.SetActive(true);
        timeText.gameObject.SetActive(false);
        if (id <= totalScenarios)
        {
            Finish.SetActive(false);
            Next.SetActive(true);
        }
        else
        {
            id = 1;
            Finish.SetActive(true);
            Next.SetActive(false);
        }

        //Debug.Log("Times Clicked: " + clicks + "\t" + "First Click: " + timeTaken + " seconds" + "\t"+ "Choice Made: " + curr_out);
    }

    //https://stackoverflow.com/questions/45046256/move-ui-recttransform-to-world-position
    public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos)
    {
        //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        //Convert the screenpoint to ui rectangle local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        //Convert the local point to world point
        return parentCanvas.transform.TransformPoint(movePos);
    }
}
