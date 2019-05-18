using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSwitch : MonoBehaviour
{
    Scenario sce;
    // Start is called before the first frame update
    void Start()
    {
        sce = GameObject.FindGameObjectWithTag("Scenario").GetComponent<Scenario>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Switch")
        {
            //Debug.Log("hit");
            int test = other.GetComponentInChildren<TrackSwitchButton>().choice;
            other.gameObject.SetActive(false);
            sce.m_Animator.SetInteger("Track", test);
            sce.curr_out = test;
            //Debug.Log(test);
            //Debug.Log(sce.curr_out);
        }
        if (other.tag == "Finish")
        {
            //Debug.Log("end");
            sce.ScenearioEnd();
        }
        
    }
}
