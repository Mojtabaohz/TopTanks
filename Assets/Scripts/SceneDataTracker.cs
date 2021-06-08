using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class SceneDataTracker : MonoBehaviour
{
    public float sceneTimer;
    private String currentScene;
    private static bool created = false;

    void Awake()
    {
        //Debug.Log("Awake:" + SceneManager.GetActiveScene().name);

        // Ensure the script is not deleted while loading.
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            //Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void Update()
    {
        sceneTimer += Time.deltaTime;
        
    }

    public void LoadScene(string sceneName)
    {
        AnalyticsResult timeSpent = Analytics.CustomEvent("Time Spent on Scene" ,
            new Dictionary<string, object>
        {
            {currentScene , sceneTimer} 
        } 
            );
        //Debug.Log("Analytics Result"+ timeSpent +" : "+ sceneTimer );
        //Debug.Log("Analytics Result sceneName : "+ currentScene );
        SceneManager.LoadScene(sceneName);
    }


}
