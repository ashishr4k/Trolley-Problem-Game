using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    
    public GameController gameController;
    public GameObject button;
    private int numScenarios;
    public bool[] levelState;
    public Sprite tick;
    public Sprite noTick;
    public GameObject trainBtn;
    public GameObject carBtn;
    public GameObject noLevels;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        numScenarios = GetLevels().Length;
        Debug.Log(numScenarios);
        float size = 3f;
        float offsetx = 1f;
        float offsety = 0f;
        for (int i = 0; i < numScenarios; i++)
        {
            
            button.GetComponentInChildren<LevelButton>().num = i + 1;
            if (i % 6 == 0 && i!= 0)
            {
                Debug.Log("w");
                offsetx += size;
                offsety = 0f;
            }
            GameObject b = Instantiate(button, new Vector3(gameObject.transform.position.x + offsetx ,gameObject.transform.position.y - offsety, 0), Quaternion.identity);
            b.transform.parent = canvas.transform;
            offsety += 1f;
        }

        levelState = GetLevels();

        if(PlayerPrefs.GetString("Layout") == "Car")
        {
            SetPreferenceCar();
        }
        else
        {
            SetPreferenceTrain();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        //float curr = Time.timeSinceLevelLoad;
        yield return new WaitForSeconds(seconds);
        //Debug.Log(Time.timeSinceLevelLoad - curr);
        obj.SetActive(false);
    }
    public void SaveState()
    {
        if (CheckArray(levelState))
        {
            noLevels.SetActive(true);
            StartCoroutine(RemoveAfterSeconds(2, noLevels));

            //Debug.Log("NOT ALLOWED")
        }
        else
        {
            noLevels.SetActive(false);
            SetLevels(levelState);
            gameController.LoadGame();
        }
    }
    bool CheckArray(bool[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (!array[i])
            {
                return array[i];
            }
        }
        return true;
    }
    //code from https://answers.unity.com/questions/940020/playerprefsx-intarray.html for storing array in playerprefs modified for
    // Use this to set integer array
    public static void SetLevels(bool[] levels)
    {
        PlayerPrefs.SetString("Level", GetSerializedString(levels));
    }

    // Use this to get integer array
    public static bool[] GetLevels()
    {
        string[] data = PlayerPrefs.GetString("Level", "true").Split('|');
        bool[] val = new bool[data.Length];
        bool levelState;
        for (int i = 0; i < val.Length; i++)
        {
            val[i] = bool.TryParse(data[i], out levelState) ? levelState : false;
        }
        return val;
    }

    private static string GetSerializedString(bool[] data)
    {
        if (data.Length == 0) return string.Empty;

        string result = data[0].ToString();
        for (int i = 1; i < data.Length; i++)
        {
            result += ("|" + data[i]);
        }
        return result;
    }
	
	public void SetPreferenceCar(){
        PlayerPrefs.SetString("Layout", "Car");
        carBtn.GetComponent<Image>().sprite = tick;
        trainBtn.GetComponent<Image>().sprite = noTick;
        //Debug.Log(PlayerPrefs.GetString("Layout"));
	}

    public void SetPreferenceTrain()
    {
        PlayerPrefs.SetString("Layout", "Train");
        carBtn.GetComponent<Image>().sprite = noTick;
        trainBtn.GetComponent<Image>().sprite = tick;

        //Debug.Log(PlayerPrefs.GetString("Layout"));

    }
}
