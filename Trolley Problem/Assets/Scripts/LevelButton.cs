using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    //public bool state = true;
    public int num;
    LevelSelect levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("levelManager").GetComponent<LevelSelect>();
        GetComponentInChildren<TextMesh>().text = "Level " + num;
    }

    // Update is called once per frame
    void Update()
    {
        if(levelManager.levelState[num - 1])
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void OnMouseDown()
    {
        //state = !state;
        
        levelManager.levelState[num-1] = !levelManager.levelState[num -1];
        //Debug.Log(num + " is " + levelManager.levelState[num-1]);
    }
}
