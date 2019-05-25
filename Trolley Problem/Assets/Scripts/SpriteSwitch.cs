using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{
    public Sprite road;
    public Sprite tracks;
    public AudioClip car;
    public AudioClip train;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("Layout") == "Car")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = road;
            if (gameObject.tag == "Train")
            {
                gameObject.GetComponent<AudioSource>().clip = car;
                gameObject.GetComponent<AudioSource>().Pause();
                gameObject.GetComponent<AudioSource>().Play();
                Debug.Log("Car");

            }
            //Debug.Log("Car");
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tracks;

            if (gameObject.tag == "Train")
            {
                gameObject.GetComponent<AudioSource>().clip = train;
                
                Debug.Log("Train");
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
