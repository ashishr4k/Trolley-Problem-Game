﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HitSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
