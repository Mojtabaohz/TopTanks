using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class SceneDataSender : MonoBehaviour
{
    public float sceneTimer;
    private String currentSceneName;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void OnDisable()
    {
        AnalyticsResult timeSpent = Analytics.CustomEvent("Time Spent on Scene",
            new Dictionary<string, object>
            {
                {currentSceneName, sceneTimer}
            }
        );
        //Debug.Log("Analytics Result"+ timeSpent +" : "+ sceneTimer );
        //Debug.Log("Analytics Result sceneName : "+ SceneManager.GetActiveScene().name );
    }
    // Update is called once per frame
    public void Update()
    {
        sceneTimer += Time.deltaTime;
        
    }
}
