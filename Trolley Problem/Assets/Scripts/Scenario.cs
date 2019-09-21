using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenario : MonoBehaviour
{
    private static int id = 0;

    private int outcomes;        //number of choices/tracks
	public int curr_out = 2;    //current track
    public Text[] choiceText;   //Text descriptions of choices
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
    bool[] skip;    //true to skip

    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;

    public GameObject char1;
    public GameObject tutorialPanel;
    public Canvas canvas;

    public DBController db;

    // Start is called before the first frame update
    void Start()
    {
        db.StartCoroutine(db.GetScenarioData(id+1));

        totalScenarios = GetLevels().Length;
        //levels to skip
        skip = GetLevels();
        id = SkipLevels(skip, id);

        //Debug.Log("Number of Scenarios: "+totalScenarios);
        //LoadScenarioData(id);

        Vector3 offset = new Vector3(0.8f, 0.5f, 0);
        Vector3 offset2 = new Vector3(0.8f, -0.5f, 0);
        choiceText[0].transform.position = worldToUISpace(canvas, spawner1.transform.position + offset);
        choiceText[1].transform.position = worldToUISpace(canvas, spawner2.transform.position + offset);
        choiceText[2].transform.position = worldToUISpace(canvas, spawner3.transform.position + offset2);
    }

    public IEnumerator SetScenario(string data)
    {
        Debug.Log(data);

        string[] stringSeparators = new string[] { "," };
        string[] result = data.Split(stringSeparators, System.StringSplitOptions.None);

        outcomes = int.Parse(result[1]);
        people1 = int.Parse(result[2]); ;
        people2 = int.Parse(result[3]);
        people3 = int.Parse(result[4]);
        choiceText[0].text = result[5];
        choiceText[1].text = result[6];
        choiceText[2].text = result[7];
        EndScreenText.text = result[8] + " of players made the same choice as you";

        //people on tracks 
        LoadPeople(people1, spawner1);
        LoadPeople(people2, spawner2);
        LoadPeople(people3, spawner3);

        if (outcomes < 3)
        {
            Track3.SetActive(false);
            Switch2.SetActive(false);
        }

        m_Animator = train.GetComponent<Animator>();
        EndScreen.SetActive(false);

        tutorialPanel.SetActive(false);

        //Tutorial
        if (id == 0)
        {
            tutorialPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            tutorialPanel.SetActive(false);
        }
    }

    int SkipLevels(bool[] levelStates, int id)
    {
        for (int i = id; i < levelStates.Length; i++)
        {
            if (!levelStates[i])
            {
                //Debug.Log("next: "+ i);
                return i;
            }
        }
        return levelStates.Length;
    }

	public void ScenearioEnd(){

        //increment scenario id
        id++;
        id = SkipLevels(skip, id);

        //Debug.Log("Choice Made: " + m_Animator.GetInteger("Track"));
        //Debug.Log("Next Scene ID: " + id);

        //Next scenario or finish
        EndScreen.SetActive(true);

        if (id < totalScenarios)
        {
           
            Finish.SetActive(false);
            Next.SetActive(true);
        }
        else
        {
            id = 0;
            Finish.SetActive(true);
            Next.SetActive(false);
        }

        int clicks = Switch2.GetComponentInChildren<TrackSwitchButton>().getClicks();
        float timeTaken = Switch2.GetComponentInChildren<TrackSwitchButton>().getFirstTime();
        Debug.Log("Times Clicked: " + clicks + "\t" + "First Click: " + timeTaken + " seconds" + "\t"+ "Choice Made: " + curr_out);
    }

    void LoadPeople(int nPeople, GameObject startPos)
    {
        //some sort of switch statement to decide character prefab being instantiated

        for (int i = 0; i < nPeople; i++)
        {
            float offset = (float)i / 2;
            Instantiate(char1, startPos.transform.position + (offset * Vector3.right), Quaternion.identity);
        }
    }

    //code from https://answers.unity.com/questions/940020/playerprefsx-intarray.html for getting serialized array stored in playerprefs
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
