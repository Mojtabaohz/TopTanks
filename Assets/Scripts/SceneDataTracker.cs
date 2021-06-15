using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class SceneDataTracker : MonoBehaviour
{
    
    
    
    private GameObject currentScene;
    private static bool created = false;
    private bool gameIsPaused = false;

    void Awake()
    {
        //Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
    //TODO: Scene time tracker have problem with playscene. it will not track data unless it get activated 
        // Ensure the script is not deleted while loading.
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        
    }

    

    public void Start()
    {
        //currentSceneName = SceneManager.GetActiveScene().name;
        currentScene = new GameObject("currentSceneHolder");
        currentScene.AddComponent<SceneDataSender>();
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 1;
            gameIsPaused = false;
            Debug.Log("Unpause");
        }
        else
        {
            Time.timeScale = 0;
            gameIsPaused = true;
            Debug.Log("pause");
        }
        
        
    }

    

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
