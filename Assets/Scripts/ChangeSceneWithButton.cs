using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
    public float sceneTimer;
    public void Update()
    {
        sceneTimer += Time.deltaTime;
        
    }

    public void LoadScene(string sceneName)
    {
        AnalyticsResult timeSpent = Analytics.CustomEvent("Time Spent on Scene" ,
            new Dictionary<string, object>
        {
            {sceneName , sceneTimer} 
        } 
            );
        Debug.Log("Analytics Result"+ timeSpent +" : "+ sceneTimer );
        SceneManager.LoadScene(sceneName);
    }


}
