using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Database
{

    public string addResultUrl = "http://gamesinpsychology.rf.gd/addresult.php";

    public IEnumerator AddResult(int choiceMade, int millisecondsTaken, int scenarioId)
    {

        Debug.Log("Add result to DB. User chose option " + choiceMade + ". Time taken was: " + millisecondsTaken + "ms");

        var form = new WWWForm();

        form.AddField("choiceMade", choiceMade);
        form.AddField("millisecondsTaken", millisecondsTaken);
        form.AddField("scenarioId", scenarioId);

        UnityWebRequest request = UnityWebRequest.Post(addResultUrl, form);
        yield return request.SendWebRequest();
    }
}