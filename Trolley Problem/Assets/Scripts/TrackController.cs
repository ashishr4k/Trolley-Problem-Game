using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    public enum Direction { Left, Right };

    public GameObject[] switches;
    public Direction[] switchDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        
        if (switches[switches.Length-1].activeInHierarchy)
        {
            for (int i = 0; i < switches.Length; i++)
            {
                switches[i].GetComponent<TrackSwitchButton>().ChangeTracks(switchDirection[i]);
            }
        }
        else
        {
            switches[0].GetComponent<TrackSwitchButton>().ChangeTracks(switchDirection[0]);
        }
    }
}
