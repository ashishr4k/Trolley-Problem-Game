using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSwitchButton : MonoBehaviour
{
    public bool change;
    public int choice;
    public int[] tracks;
    public Sprite switchLeft;
    public Sprite switchRight;
    public Sprite arrowA;
    public Sprite arrowB;
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        choice = tracks[0];
        gameObject.GetComponent<SpriteRenderer>().sprite = switchLeft;
        arrow.GetComponentInChildren<SpriteRenderer>().sprite = arrowA;
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
            gameObject.GetComponent<SpriteRenderer>().sprite = switchRight;
            arrow.GetComponentInChildren<SpriteRenderer>().sprite = arrowB;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            choice = tracks[0];
            gameObject.GetComponent<SpriteRenderer>().sprite = switchLeft;
            arrow.GetComponentInChildren<SpriteRenderer>().sprite = arrowA;
            gameObject.GetComponent<AudioSource>().Play();

        }
    }

    void OnMouseOver()
    {

    }
}
