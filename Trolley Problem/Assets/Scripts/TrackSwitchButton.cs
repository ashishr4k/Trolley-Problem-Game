using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSwitchButton : MonoBehaviour
{
    public bool change;
    public int choice;
    public int[] tracks;
    // Start is called before the first frame update
    void Start()
    {
        choice = tracks[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        change = !change;
        //replace with sprite changes instead of colour
        if (change)
        {
            choice = tracks[1];
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            choice = tracks[0];
            GetComponent<SpriteRenderer>().color = Color.red;

        }
    }

    void OnMouseOver()
    {

    }
}
