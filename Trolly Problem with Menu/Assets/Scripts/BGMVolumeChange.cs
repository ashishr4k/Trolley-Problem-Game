using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BGMVolumeChange : MonoBehaviour
{

    public AudioSource audioSrc;

    private float musicVolume = 1f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

        public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
    
}
