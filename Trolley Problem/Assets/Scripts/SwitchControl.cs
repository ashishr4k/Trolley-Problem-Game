using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl: MonoBehaviour
{
	public Scenario sce;
    private bool canChangeChoice = true;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(""+sce.outcomes);
    }

    // Update is called once per frame
    void Update()
    {
        //temporary way of not allowing the choice to change after passing interchange (REMOVE LATER)
        //TODO: change bool with colliders instead
        if (Time.timeSinceLevelLoad > 2.5f) canChangeChoice = false;
    }

	//clicking the switch
	void OnMouseDown()
	{
        //Debug.Log("Test");
        //Code to switch tracks
        //example of switching between two choices

        //ensure that choice can't be changed after passing the interchange
        if (canChangeChoice)
        {
            //make sure the choice is within scenario bounds ie. if there are two choices loop back to choice one after clicking the switch
            if (sce.curr_out < sce.outcomes)
            {
                sce.curr_out++;

            }
            else
            {
                sce.curr_out = 1;
            }
        }
		//Debug.Log("Track: "+sce.curr_out);

        //set the animators choice value to be the current choice
        sce.m_Animator.SetInteger("Choice", sce.curr_out);

        Debug.Log("Choice Changed to: "+sce.train.GetComponent<Animator>().GetInteger("Choice"));
    }

	//hovering over the switch
	void OnMouseOver()
	{
		//Debug.Log("hover");
		//Some sort of feedback when hovering over better indication of object?
	}
}
