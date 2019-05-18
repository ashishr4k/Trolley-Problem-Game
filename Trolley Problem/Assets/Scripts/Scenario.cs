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
    public float sce_time = 7f;
    public int people1;
    public int people2;
    public int people3;
    public GameObject[] pTrack1;
    public GameObject[] pTrack2;
    public GameObject[] pTrack3;


    public GameObject Track3;
    public GameObject Switch2;

    const int totalScenarios = 3;
    bool[] skip;    //true to skip

    // Start is called before the first frame update
    void Start()
    {
        //levels to skip
        skip = GetLevels();
        //if (skip[id])
        {
            id = SkipLevels(skip, id);
        }
        for (int i = 0; i < skip.Length; i++)
        {
            //Debug.Log(skip[i]);
        }
        //Debug.Log("Number of Scenarios: "+totalScenarios);
        LoadScenarioData(id);
        

        if (outcomes < 3)
        {
            Track3.SetActive(false);
            Switch2.SetActive(false);
        }

        m_Animator = train.GetComponent<Animator>();
        EndScreen.SetActive(false);

        //people on tracks
        generatePeople(people1, pTrack1);
        generatePeople(people2, pTrack2);
        generatePeople(people3, pTrack3);
    }

    // Update is called once per frame
    void Update()
    {

    }
    int SkipLevels(bool[] array, int id)
    {
        for (int i = id; i < array.Length; i++)
        {
            if (!array[i])
            {
                //Debug.Log("next: "+ i);

                return i;
            }
        }
        return array.Length;
    }
	public void ScenearioEnd(){

        //increment scenario id
        id++;
        id = SkipLevels(skip, id);
        //if (skip[id])
        {
            //id = SkipLevels(skip, id);
        }

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
    }

    void generatePeople(int people, GameObject[] track)
    {
        for (int i = 0; i < people; i++)
        {
            track[i].SetActive(true);
        }
    }

    //some hardcoded data for scenarios
    int[] numTracks = { 2, 3, 3 };
    int[] onTrack1 = { 1, 2, 1 };
    int[] onTrack2 = { 2, 1, 1 };
    int[] onTrack3 = { 0, 2, 1 };
    string[] infoTrack1 = { "An adult", "Two homeless adults","Your friend" };
    string[] infoTrack2 = { "Two elderly men", "A homeless child", "Your Neighbour" };
    string[] infoTrack3 = { "", "A wealthy couple", "Your boss" };
    string[] endText = { "50 % picked the same choice", "50 % picked the same choice", "50 % picked the same choice" };
    void LoadScenarioData(int id)
    {
        outcomes = numTracks[id];
        people1 = onTrack1[id];
        people2 = onTrack2[id];
        people3 = onTrack3[id];
        choiceText[0].text = infoTrack1[id];
        choiceText[1].text = infoTrack2[id];
        choiceText[2].text = infoTrack3[id];
        EndScreenText.text = endText[id];
    }


    //code from https://answers.unity.com/questions/940020/playerprefsx-intarray.html for storing array in playerprefs modified for use
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
}
