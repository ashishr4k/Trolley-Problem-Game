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

    }
    // Update is called once per frame
    void Update()
    {
          if(PlayerPrefs.GetString("Layout") == "Car"){
              if (gameObject.tag != "Train")gameObject.GetComponent<SpriteRenderer>().sprite = road;
          }else{
              if (gameObject.tag != "Train")gameObject.GetComponent<SpriteRenderer>().sprite = tracks;
          }
    }

    public void SetLayout(string layout){
        if(layout == "Car")
        {
            PlayerPrefs.SetString("Layout", "Car");
            gameObject.GetComponent<SpriteRenderer>().sprite = road;
            gameObject.GetComponent<AudioSource>().clip = car;
            //gameObject.GetComponent<AudioSource>().Pause();
            //gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            PlayerPrefs.SetString("Layout", "Train");
            gameObject.GetComponent<SpriteRenderer>().sprite = tracks;
            gameObject.GetComponent<AudioSource>().clip = train;
            //gameObject.GetComponent<AudioSource>().Pause();
            //gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
