using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenario : MonoBehaviour
{
	public int outcomes;
	public int curr_out = 1;
    private float sce_time = 5f;
    //private bool over = false;
    private static int id;
    //Text descriptions of choices
    public Text choiceA;
    public Text choiceB;

    public GameObject train;
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        //Replace with call from database if storing scenario info in database
        choiceA.text = "Description of A";
        choiceB.text = "Description of B";
        //Debug.Log(id);
        m_Animator =  train.GetComponent<Animator>();
        Debug.Log(m_Animator.GetInteger("Choice"));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log((int)Time.timeSinceLevelLoad);
        //Example call to end scenario if using timer instead of checking when train reaches end of track
        //if (Time.timeSinceLevelLoad > sce_time)
        {
            //ScenearioEnd();
        }
    }

	void ScenearioEnd(){
        //code to write to database and display stats from database
        id++;
        Debug.Log("Next Scene ID: " + id);
        //over = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
