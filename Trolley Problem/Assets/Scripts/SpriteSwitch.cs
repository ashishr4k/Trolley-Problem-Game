using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{
    public Sprite road;
    public Sprite tracks;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("Layout") == "Car")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = road;
            //Debug.Log("Car");
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tracks;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
