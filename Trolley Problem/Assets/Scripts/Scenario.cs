using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenario : MonoBehaviour
{
	public int outcomes;
	public int curr_out = 1;
    //Text descriptions of choices
    public Text choiceA;
    public Text choiceB;

    public GameObject train;
    public Animator m_Animator;
    public GameObject EndScreen;
    public float sce_time = 7f;
    private static int id;
    bool over = false;
    // Start is called before the first frame update
    void Start()
    {
        //Replace with call from database if storing scenario info in database
        choiceA.text = "Description of A";
        choiceB.text = "Description of B";
        //Debug.Log(id);
        m_Animator = train.GetComponent<Animator>();
        EndScreen.SetActive(false);
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

        //End screen
        EndScreen.SetActive(true);
        
    }
    public void ReloadScene()
    {
        //reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
