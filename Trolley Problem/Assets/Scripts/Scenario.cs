using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenario : MonoBehaviour
{
    private static int id;
  

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
    bool over = false;
    public int people1;
    public int people2;
    public int people3;
    public GameObject[] pTrack1;
    public GameObject[] pTrack2;
    public GameObject[] pTrack3;


    public GameObject Track3;
    public GameObject Switch2;

    int totalScenarios = 1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Number of Scenarios: "+totalScenarios);
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
        //Debug.Log((int)Time.timeSinceLevelLoad);
        //Example call to end scenario if using timer instead of checking when train reaches end of track
        if (Time.timeSinceLevelLoad > sce_time && !over)
        {
            ScenearioEnd();
        }
    }

	void ScenearioEnd(){
        //code to write to database and display stats from database

        
        //increment scenario id
        id++;
        over = true;

        Debug.Log("Choice Made: " + m_Animator.GetInteger("Choice"));
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
    int[] onTrack2 = { 3, 1, 1 };
    int[] onTrack3 = { 0, 2, 1 };
    string[] infoTrack1 = { "Test", "Test3","Test5" };
    string[] infoTrack2 = { "Test2", "Test4", "Test6" };
    string[] infoTrack3 = { "", "Testb", "Testc" };
    string[] endText = { "% Test", "% Test2", "% Test3" };
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
}
