using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl: MonoBehaviour 
{
	public Scenario sce;
    private bool canChangeChoice = true;    //not currently used
    public int[] betweenO;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(sce.outcomes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	//clicking the switch
	void OnMouseDown()
	{

        //ensure that choice can't be changed after passing the interchange
        if (canChangeChoice)
        {
            if (sce.curr_out == betweenO[0])
            {
                sce.curr_out = betweenO[1];
            }
            else if(sce.curr_out == betweenO[1])
            {
                sce.curr_out = betweenO[0];
            }
            
        }
		//Debug.Log("Track: "sce.curr_out);

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
