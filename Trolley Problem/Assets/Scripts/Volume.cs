using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Volume : MonoBehaviour
{

    public AudioSource audioSrc;
	public Slider slider;
	public Toggle muteBtn;

    void Start()
    {
        audioSrc = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
    }
    void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (muteBtn.isOn)
        {
            audioSrc.volume = 0;
        }
        else
        {
            audioSrc.volume = slider.value;
        }
    }
}
