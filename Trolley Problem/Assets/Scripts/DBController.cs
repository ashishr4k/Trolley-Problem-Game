using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBController : MonoBehaviour
{

    string getDataUrl = "http://kit301-games.cis.utas.edu.au/scripts/data.php?ID=";
    string submitDataUrl = "http://kit301-games.cis.utas.edu.au/scripts/insert.php";
    string exportUrl = "http://kit301-games.cis.utas.edu.au/scripts/export.php";
    string scenarioListUrl = "http://kit301-games.cis.utas.edu.au/scripts/listScenarios.php";

    public IEnumerator GetScenarioData(int id, System.Action<string, bool> callback)
    {
        UnityWebRequest www = UnityWebRequest.Get(getDataUrl + id);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            string data = null;
            callback(data, false);
        }
        else
        {
            string data = www.downloadHandler.text;
            callback(data, true);
        }
    }

    public IEnumerator GetTotal(int id, System.Action<int,bool> callback)
    {
        UnityWebRequest www = UnityWebRequest.Get(getDataUrl + id);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            callback(-1, false);
        }
        else
        {
            string data = www.downloadHandler.text;
            string[] stringSeparators = new string[] { "," };
            string[] result = data.Split(stringSeparators, System.StringSplitOptions.None);
            int totalScenarios = int.Parse(result[result.Length - 1]);
            callback(totalScenarios,true);
        }
    }

    public IEnumerator GetScenarioList(System.Action<string,bool> callback){
        UnityWebRequest www = UnityWebRequest.Get(scenarioListUrl);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            string data = null;
            callback(data, false);
        }
        else
        {
            string data = www.downloadHandler.text;
            //Debug.Log(data);
            callback(data,true);
        }
    }

    public IEnumerator Submit(int id, int clicks, float time, int choice)
    {
        WWWForm form = new WWWForm();
        form.AddField("scenario", id);
        form.AddField("clicks", clicks);
        form.AddField("time", Mathf.RoundToInt(time * 1000));
        form.AddField("choice", choice);

        using (UnityWebRequest www = UnityWebRequest.Post(submitDataUrl, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log("Form upload complete!");
            }
        }
    }

    public IEnumerator Export()
    {
        WWWForm form = new WWWForm();
        form.AddField("empty", "myData");

        UnityWebRequest www = UnityWebRequest.Post(exportUrl, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
    }
}
