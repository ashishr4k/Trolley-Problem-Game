using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrackSwitch : MonoBehaviour
{
    Scenario sce;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sce = GameObject.FindGameObjectWithTag("Scenario").GetComponent<Scenario>();
        sce.m_Animator.speed = speed;
        gameObject.GetComponent<AudioSource>().pitch = speed;
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
            other.GetComponent<PersonHit>().HitSound();
        }
    }
}
