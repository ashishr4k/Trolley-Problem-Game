using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceText : MonoBehaviour
{
    //description text
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        text.SetActive(true);
    }

    void OnMouseExit()
    {
        text.SetActive(false);
    }
}
