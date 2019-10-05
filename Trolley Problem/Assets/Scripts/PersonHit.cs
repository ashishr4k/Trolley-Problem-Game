using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonHit : MonoBehaviour
{
    public GameObject parts;
    public GameObject part1;
    public GameObject part2;

    public void Hit()
    {
        gameObject.GetComponent<AudioSource>().Play();
        parts.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
    }}
