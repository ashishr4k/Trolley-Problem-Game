using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Volume : MonoBehaviour
{
    
    public AudioListener audioLis;
	public Slider slider;
	public Toggle muteBtn;

    void Start()
    {
        slider.value = AudioListener.volume;
        muteBtn.isOn = AudioListener.pause;
    }
    void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (muteBtn.isOn)
        {
            AudioListener.pause = true;
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.pause = false;
            AudioListener.volume = slider.value;
        }
    }
}
