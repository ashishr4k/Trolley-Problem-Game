using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LayoutControl : MonoBehaviour
{
    public Sprite tick;
    public Sprite noTick;
    public GameObject trainBtn;
    public GameObject carBtn;

    // Start is called before the first frame update
    void Start()
    {
      if(PlayerPrefs.GetString("Layout") == "Car")
      {
          SetLayout("Car");
      }
      else
      {
          SetLayout("Train");
      }
    }

    public void SetLayout(string pref){
      if(pref == "Car"){
          PlayerPrefs.SetString("Layout", pref);
          carBtn.GetComponent<Image>().sprite = tick;
          trainBtn.GetComponent<Image>().sprite = noTick;
      }else if (pref == "Train"){
          PlayerPrefs.SetString("Layout", pref);
          carBtn.GetComponent<Image>().sprite = noTick;
          trainBtn.GetComponent<Image>().sprite = tick;
      }
    }
}
