using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrackSwitch : MonoBehaviour
{
    Scenario sce;
    public float speed = 1f;

    Database db = new Database();
    DateTime startTime, lastSwitchTime;

    // Start is called before the first frame update
    void Start()
    {
        sce = GameObject.FindGameObjectWithTag("Scenario").GetComponent<Scenario>();
        sce.m_Animator.speed = speed;
        gameObject.GetComponent<AudioSource>().pitch = speed;

        startTime = DateTime.Now;

    }

    // Update is called once per frame
    void Update()
    {
        sce.m_Animator.speed = speed;
        gameObject.GetComponent<AudioSource>().pitch = speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "Switch")
        {
            //Debug.Log("hit");
            int test = other.GetComponentInChildren<TrackSwitchButton>().choice;
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponentInChildren<TrackSwitchButton>().locked = true;
            sce.m_Animator.SetInteger("Track", test);
            sce.curr_out = test;
            //Debug.Log(test);
            //Debug.Log(sce.curr_out);
        }
        if (other.tag == "Finish")
        {
            //Determine choice made
            int choice;

            float ypos = this.GetComponent<Rigidbody2D>().position.y;
            if (ypos < -1)
                choice = 2;
            else if (ypos > 0)
                choice = 3;
            else
                choice = 1;

            //Get time taken
            TimeSpan diff = DateTime.Now - startTime;
            int timeTaken = (int)diff.TotalMilliseconds;

            //Store result in database
            StartCoroutine(db.AddResult(choice, timeTaken, 0));

            //Show the scenario end screen
            sce.ScenearioEnd();
        }

        if (other.tag == "Person")
        {
            other.GetComponent<PersonHit>().HitSound();
        }
    }
}
