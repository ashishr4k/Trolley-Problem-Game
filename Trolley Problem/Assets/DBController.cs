using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBController : MonoBehaviour
{

    string requestUrl = "http://kit301-games.cis.utas.edu.au/data.php?ID=";
    public Scenario sc;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Load(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GetScenarioData(int id)
    {
        UnityWebRequest www = UnityWebRequest.Get(requestUrl + id);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string data = www.downloadHandler.text;
            yield return sc.SetScenario(data);
        }
    }
}
