using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrackSwitch : MonoBehaviour
{
    Scenario sce;
    public float speed = 1f;
    private int WaitTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        sce = GameObject.FindGameObjectWithTag("Scenario").GetComponent<Scenario>();
        GetComponent<Animator>().enabled = false;
        GetComponent<AudioSource>().Stop();
    }

    IEnumerator waitForTime(){
        yield return new WaitForSeconds(WaitTime);
        //Debug.Log("start");
        GetComponent<Animator>().enabled = true;
        GetComponent<AudioSource>().Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Switch")
        {
            int test = other.GetComponentInChildren<TrackSwitchButton>().choice;
            other.gameObject.GetComponentInChildren<TrackSwitchButton>().locked = true;
            sce.m_Animator.SetInteger("Track", test);
            sce.curr_out = test;
        }
        if (other.tag == "Finish")
        {
            //Show the scenario end screen
            sce.ScenearioEnd();
        }

        if (other.tag == "Person")
        {
            other.GetComponent<PersonHit>().Hit();
        }
    }

    public void SetWaitTime(int time){
        WaitTime = time;
        StartCoroutine("waitForTime");
    }
}
