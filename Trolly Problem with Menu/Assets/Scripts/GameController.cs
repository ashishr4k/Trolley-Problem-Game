using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Scenario sce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadScene()
    {
        //reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadResultsScene()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("trst");
    }
}
