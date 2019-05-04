using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenario : MonoBehaviour
{
	public int outcomes;
	public int curr_out = 1;

    //Text descriptions of choices
    public Text choiceA;
    public Text choiceB;

    // Start is called before the first frame update
    void Start()
    {
        //Replace with call from database if storing scenario info in database
        choiceA.text = "Description of A";
        choiceB.text = "Description of B";
    }

    // Update is called once per frame
    void Update()
    {
        //Example call to end scenario if using timer instead of checking when train reaches end of track
        //if (Time.time > someTimeValue) ScenearioEnd();
    }

	void ScenearioEnd(){
		//code to write to database and display stats from database
	}
}
