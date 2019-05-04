using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl: MonoBehaviour
{
	public Scenario sce;
    // Start is called before the first frame update

    void Start()
    {
		//Debug.Log(""+sce.outcomes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	//clicking the switch
	void OnMouseDown()
	{
		//Debug.Log("Test");
		//Code to switch tracks


		//example of switching between two choices
		if(sce.curr_out < sce.outcomes){
			sce.curr_out++;
            sce.train.GetComponent<Animator>().SetInteger("Choice", sce.curr_out);
		}else{
			sce.curr_out = 1;
		}
		Debug.Log("Track: "+sce.curr_out);
	}

	//hovering over the switch
	void OnMouseOver()
	{
		//Debug.Log("hover");
		//Some sort of feedback when hovering over better indication of object?
	}
}
