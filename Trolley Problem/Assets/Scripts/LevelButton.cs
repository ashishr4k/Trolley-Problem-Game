using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    //public bool state = true;
    public int num;
    LevelSelect levelManager;
    public GameObject text;
    public Sprite tick;
    public Sprite noTick;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("levelManager").GetComponent<LevelSelect>();
        text.GetComponent<TextMesh>().text = "Level " + num;
    }

    // Update is called once per frame
    void Update()
    {
        if(levelManager.levelState[num - 1])
        {
            //GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.GetComponent<SpriteRenderer>().sprite = noTick;
        }
        else
        {
            //GetComponent<SpriteRenderer>().color = Color.green;
            gameObject.GetComponent<SpriteRenderer>().sprite = tick;

        }
    }

    void OnMouseDown()
    {
        //state = !state;
        
        levelManager.levelState[num-1] = !levelManager.levelState[num -1];
        //Debug.Log(num + " is " + levelManager.levelState[num-1]);
    }
}
