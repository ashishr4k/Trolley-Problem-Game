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
    public bool locked;
    public static float timeTaken;
    public static int clicks;

    private bool firstClick;
    // Start is called before the first frame update
    void Start()
    {
        locked = false;
        firstClick = true;
        clicks = 0;
        timeTaken = 0;
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
        if (!locked)
        {
            clicks++;
            change = !change;

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

            if (firstClick)
            {
                timeTaken = Time.timeSinceLevelLoad;
                //Debug.Log(timeTaken);
                firstClick = false;
            }


        }
    }

    public void ChangeTracks(TrackController.Direction direction)
    {
        if (!locked)
        {
            clicks++;
            change = !change;

            if (firstClick)
            {
                timeTaken = Time.timeSinceLevelLoad;
                firstClick = false;
            }

            if (direction == TrackController.Direction.Left)
            {
                choice = tracks[1];
                gameObject.GetComponent<SpriteRenderer>().sprite = switchRight;
                arrow.GetComponentInChildren<SpriteRenderer>().sprite = arrowB;
                gameObject.GetComponent<AudioSource>().Play();
            }

            if (direction == TrackController.Direction.Right)
            {
                choice = tracks[0];
                gameObject.GetComponent<SpriteRenderer>().sprite = switchLeft;
                arrow.GetComponentInChildren<SpriteRenderer>().sprite = arrowA;
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    void OnMouseOver()
    {

    }

    public int getClicks()
    {
        return clicks;
    }

    public float getFirstTime()
    {
        return timeTaken;
    }
}
